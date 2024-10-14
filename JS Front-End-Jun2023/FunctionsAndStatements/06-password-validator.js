function isPasswordValid(password) {
  let invalid = false;

  if (password.length < 6 || password.length > 10) {
    invalid = true;
    console.log("Password must be between 6 and 10 characters");
  }

  if (!/^[0-9a-zA-Z]+$/.test(password)) {
    invalid = true;
    console.log("Password must consist only of letters and digits");
  }

  if (!/\d{2,}/.test(password)) {
    invalid = true;
    console.log("Password must have at least 2 digits");
  }

  if (!invalid) {
    console.log("Password is valid");
  }
}

//isPasswordValid('Pa$s$s');
