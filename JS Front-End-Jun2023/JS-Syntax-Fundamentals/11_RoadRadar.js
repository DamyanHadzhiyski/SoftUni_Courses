function roadRadar(speed, area) {
  let speedLimit = 0;

  switch (area) {
    case "motorway":
      speedLimit = 130;
      break;
    case "interstate":
      speedLimit = 90;
      break;
    case "city":
      speedLimit = 50;
      break;
    case "residential":
      speedLimit = 20;
      break;
  }

  let speedStatus = "";
  let speedDifference = speed - speedLimit;

  if (speedDifference > 0 && speedDifference <= 20) {
    speedStatus = "speeding";
  } else if (speedDifference <= 40) {
    speedStatus = "excessive speeding";
  } else if (speedDifference > 40) {
    speedStatus = "reckless driving";
  }

  if (speedDifference <= 0) {
    console.log(`Driving ${speed} km/h in a ${speedLimit} zone`);
  } else {
    console.log(
      `The speed is ${speedDifference} km/h faster than the allowed speed of ${speedLimit} - ${speedStatus}`
    );
  }
}

//roadRadar(200, 'motorway');
