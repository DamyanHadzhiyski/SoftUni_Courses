function printIfPalindroms(numbers) {
  for (const number of numbers) {
    let numberAsString = number.toString();
    let lastPos = numberAsString.length - 1;
    let result = true;

    for (let i = 0; i < numberAsString.length / 2; i++) {
      if (numberAsString[i] !== numberAsString[lastPos - i]) {
        result = false;
        break;
      }
    }

    if (result) {
      console.log("true");
    } else {
      console.log("false");
    }
  }
}

//printIfPalindroms([32, 2, 232, 1010]);
