function sortNames(names) {
    names.sort(function(a,b){return a.toLowerCase().localeCompare(b.toLowerCase())});

    for (let index = 0; index < names.length; index++) {
        console.log(`${index + 1}.${names[index]}`);
    }
}

//sortNames(["John", "bob", "Bob", "Christina", "Ema"]);