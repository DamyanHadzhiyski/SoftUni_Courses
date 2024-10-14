function arrayRotation(array, rotations) {
  let rotatedArray = array;

  for (let index = 0; index < rotations; index++) {
    let element = rotatedArray.shift();
    rotatedArray.push(element);
  }

  console.log(rotatedArray.join(" "));
}

//arrayRotation([32, 21, 61, 1], 4);