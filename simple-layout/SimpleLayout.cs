﻿using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace SimpleLayout
{
    static class TestImages
    {
        private const string resources = "./res";

        /// Child image filenames
        public static readonly string[] s_images = new string[]
        {
            resources + "/images/application-icon-101.png",
            resources + "/images/application-icon-102.png",
            resources + "/images/application-icon-103.png",
            resources + "/images/application-icon-104.png"
        };
    }

    class SimpleLayout : NUIApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        private void Initialize()
        {
            // Change the background color of Window to White & respond to key events
            Window window = Window.Instance;
            window.BackgroundColor = Color.White;
            window.KeyEvent += OnKeyEvent;

            // Create a new view
            View customLayoutView = new View();
            customLayoutView.Name = "CustomLayoutView";
            customLayoutView.ParentOrigin = ParentOrigin.Center;
            customLayoutView.PivotPoint = PivotPoint.Center;
            customLayoutView.PositionUsesPivotPoint = true;
            // Set our Custom Layout on the view
            var layout = new CustomLayout();
            customLayoutView.Layout = layout;
            customLayoutView.WidthSpecification = LayoutParamPolicies.WrapContent;
            customLayoutView.HeightSpecification = 350;
            customLayoutView.BackgroundColor = Color.Blue;
            window.Add( customLayoutView );

            // Add child image-views to the created view
            foreach (String image in TestImages.s_images)
            {
                customLayoutView.Add( CreateChildImageView( image, new Size2D( 100, 100 ) ) );
            }
        }

        /// <summary>
        /// Helper function to create ImageViews with given filename and size..<br />
        /// </summary>
        /// <param name="filename"> The filename of the image to use.</param>
        /// <param name="size"> The size that the image should be loaded at.</param>
        /// <returns>The created ImageView.</returns>
        ImageView CreateChildImageView( String url, Size2D size )
        {
            ImageView imageView = new ImageView();
            ImageVisual imageVisual = new ImageVisual();

            imageVisual.URL = url;
            imageVisual.DesiredHeight = size.Height;
            imageVisual.DesiredWidth = size.Width;
            imageView.Image = imageVisual.OutputVisualMap;

            imageView.Name = "ImageView";
            imageView.HeightResizePolicy = ResizePolicyType.Fixed;
            imageView.WidthResizePolicy = ResizePolicyType.Fixed;
            return imageView;
        }

        /// <summary>
        /// Called when any key event is received.
        /// Will use this to exit the application if the Back or Escape key is pressed
        /// </summary>
        private void OnKeyEvent( object sender, Window.KeyEventArgs eventArgs )
        {
            if( eventArgs.Key.State == Key.StateType.Down )
            {
                switch( eventArgs.Key.KeyPressedName )
                {
                    case "Escape":
                    case "Back":
                    {
                        Exit();
                    }
                    break;
                }
            }
        }

        static void Main(string[] args)
        {
            SimpleLayout simpleLayout = new SimpleLayout();
            simpleLayout.Run(args);
        }
    }
}
