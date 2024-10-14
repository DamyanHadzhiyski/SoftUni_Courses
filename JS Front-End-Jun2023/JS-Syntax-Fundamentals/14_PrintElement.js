function printElement(array, step) {
  const resultingArray = [];
  for (let index = 0; index < array.length; index++) {
    if (index % step === 0) {
      resultingArray.push(array[index]);
    }
  }

  return resultingArray;
}

//console.log(printElement(["dsa", "asd", "test", "tset"], 2));
