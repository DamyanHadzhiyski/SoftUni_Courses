function createMatrix(n){
    const row = [];

    for (let i = 0; i < n; i++){
        row[i] = n;
    }

    for (let i = 0; i < n; i++){
        console.log(row.join(" "));
    }
}

//createMatrix(3);