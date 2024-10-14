function parkingEntrance(input) {
  const parking = new Set();

  input.forEach((entry) => {
    const [command, number] = entry.split(", ");

    if (command === "IN") {
      parking.add(number);
    } else if (command === "OUT") {
      parking.delete(number);
    }
  });

  const carNumbers = Array.from(parking).sort((a, b) => a.localeCompare(b));

  if (carNumbers.length > 0) {
    console.log(carNumbers.join("\n"));
  } else {
    console.log("Parking Lot is Empty");
  }
}
