function storeProvisions(available, ordered) {
  let storage = [];

  for (let i = 0; i < available.length; i += 2) {
    storage.push(available[i]);
    storage.push(Number(available[i + 1]));
  }

  for (let i = 0; i < ordered.length; i += 2) {
    if (!storage.includes(ordered[i])) {
      storage.push(ordered[i]);
      storage.push(Number(ordered[i + 1]));
      continue;
    }

    let qtyIndex = storage.indexOf(ordered[i]) + 1;
    storage[qtyIndex] += Number(ordered[i + 1]);
  }

  for (let i = 0; i < storage.length; i += 2) {
    console.log(`${storage[i]} -> ${storage[i + 1]}`);
  }
}

// storeProvisions(
//   ["Salt", "2", "Fanta", "4", "Apple", "14", "Water", "4", "Juice", "5"],
//   ["Sugar", "44", "Oil", "12", "Apple", "7", "Tomatoes", "7", "Bananas", "30"]
// );
