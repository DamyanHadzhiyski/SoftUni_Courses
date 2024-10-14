function cookingByNumebrs(number, ...operations) {
  let resultingNumber = parseInt(number);

  for (let oper of operations) {
    switch (oper) {
      case "chop":
        resultingNumber /= 2;
        break;
      case "dice":
        resultingNumber = Math.sqrt(resultingNumber);
        break;
      case "spice":
        resultingNumber += 1;
        break;
      case "bake":
        resultingNumber *= 3;
        break;
      case "fillet":
        resultingNumber -= resultingNumber * 0.2;
        break;
    }

    console.log(resultingNumber);
  }
}

//cookingByNumebrs('9', 'dice', 'spice', 'chop', 'bake', 'fillet');