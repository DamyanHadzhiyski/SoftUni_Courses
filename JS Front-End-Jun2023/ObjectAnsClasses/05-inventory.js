function createHeroRegistry(input) {
  let heroRegistry = [];

  const sortedInput = input
    .map((element) => {
      return element.split(" / ");
    })
    .sort((a, b) => a[1] - b[1]);

  sortedInput.map((heroInfo) => {
    const [name, level, ...items] = heroInfo;
    heroRegistry.push({
      name,
      level: Number(level),
      items,
      print() {
        console.log(`Hero: ${this.name}`);
        console.log(`level => ${this.level}`);
        console.log(`items => ${items.join(", ")}`);
      },
    });
  });

  const sortedHeroRegistry = heroRegistry;
  heroRegistry.forEach((hero) => hero.print());
}

// createHeroRegistry([
//   "Isacc / 25 / Apple, GravityGun",
//   "Derek / 12 / BarrelVest, DestructionSword",
//   "Hes / 1 / Desolator, Sentinel, Antara",
// ]);
