## Welcome to Slipstream Engine
---
Slipstream Engine is a game framework created in C# meant to create console based games.
[Documentation](https://github.com/SaladClimbing/SlipstreamEngine/wiki)

### What it does
Slipstream Engine allows you to create games with minimal code. For example, a game with a main menu and options menu looks something like this:
```c#
using SlipstreamEngine.Menus;
using SlipstreamEngine.InputManager;

Window window = new Window();
InputManager im = InputManager.GetInstance;
im.setWindow(window);
MainMenu mainMenu = new MainMenu("gameName", true, true);
mainMenu.displayMenu(window, { Action });
Application.Run(window);
```
Everything from exiting the game, to an action to run when played is all handled in this small amount of code.

### About Slipstream Engine
Slipstream Engine is designed to make console based games more simple than ever. Slipstream Engine is meant to do most of the heavy lifting for you, although you can customize what happens if you so wish. I am aware Slipstream may not be completely optimized in every possible way, but due to the simplicity of the games it creates performance isn't anything you should be worried about. If you seem to be having performance issues please file a GitHub issue on the GitHub repository

View the [NuGet Package](https://www.nuget.org/packages/SlipstreamEngine/)
<!--
You can use the [editor on GitHub](https://github.com/SaladClimbing/SlipstreamEngine/edit/gh-pages/index.md) to maintain and preview the content for your website in Markdown files.

Whenever you commit to this repository, GitHub Pages will run [Jekyll](https://jekyllrb.com/) to rebuild the pages in your site, from the content in your Markdown files.

### Support or Contact

Having trouble with Pages? Check out our [documentation](https://docs.github.com/categories/github-pages-basics/) or [contact support](https://support.github.com/contact) and we’ll help you sort it out.
-->
