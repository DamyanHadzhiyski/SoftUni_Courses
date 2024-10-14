function calculate(num1, num2) {
  let factorialNum1 = 1
    let factorialNum2 = 1

    for (let i = 1; i <= num1; i++) {
      factorialNum1 *= i
    }

    for (let i = 1; i <= num2; i++) {
      factorialNum2 *= i
    }

    let result = factorialNum1 / factorialNum2
    console.log(result.toFixed(2))
}

//calculate(5, 2);
