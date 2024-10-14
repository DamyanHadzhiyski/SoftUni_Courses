function moneyToBuyFruits(fruitType, weightInGrams, pricePerKg) {
    let weight = weightInGrams / 1000;
    let money = weight * pricePerKg;
    console.log(`I need $${money.toFixed(2)} to buy ${weight.toFixed(2)} kilograms ${fruitType}.`)
}

//moneyToBuyFruits('apple', 1563, 2.35);