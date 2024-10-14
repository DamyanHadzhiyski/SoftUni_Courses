function createTownTable(inputArray) {
    let townsTable = [];

    townsTable = inputArray.map((city) => {
        const [town, latitude, longitude] = city.split(" | ");
        return {town: town, latitude: Number(latitude).toFixed(2), longitude: Number(longitude).toFixed(2)};
    });

    townsTable.forEach((town) => {
        console.log(town);
    });
}

// createTownTable([
//   "Sofia | 42.696552 | 23.32601",
//   "Beijing | 39.913818 | 116.363625",
// ]);
