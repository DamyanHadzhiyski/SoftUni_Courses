function createEmployeeList(employeesNames) {
  let employees = [];

  employees = employeesNames.reduce((acc, cur) => {
    acc[cur] = cur.length;
    return acc;
  }, {});

  Object.entries(employees).forEach(([name, num]) =>
    console.log(`Name: ${name} -- Personal Number: ${num}`)
  );
}

createEmployeeList([
  "Samuel Jackson",
  "Will Smith",
  "Bruce Willis",
  "Tom Holland",
]);
