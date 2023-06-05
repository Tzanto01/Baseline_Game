using Core.Handlers;
using Core.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Core
{
    public class CoreGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private readonly UpdateHandler _updateHandler;
        private readonly DrawHandler _drawHandler;
        private readonly LoadContentHandler _loadContentHandler;

        public CoreGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _updateHandler = new UpdateHandler();
            _drawHandler = new DrawHandler();
            _loadContentHandler = new LoadContentHandler();

            TextureManager.SetContent(Content);
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            var ball = new Ball();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _loadContentHandler.Handle();
        }

        protected override void Update(GameTime pGameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _updateHandler.Handle(pGameTime);

            base.Update(pGameTime);
        }

        protected override void Draw(GameTime pGameTime)
        {
            _graphics.GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();
            _drawHandler.Handle(pGameTime, _spriteBatch);
            _spriteBatch.End();

            base.Draw(pGameTime);
        }

        public GraphicsDeviceManager GetGraphics() => _graphics;
    }
}