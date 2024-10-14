using E03.Raiding.Core;
using E03.Raiding.Core.Interfaces;
using E03.Raiding.Factories;
using E03.Raiding.Factories.Interfaces;

IHeroFactory heroFactory = new HeroFactory();

IEngine engine = new Engine(heroFactory);

engine.Run();
