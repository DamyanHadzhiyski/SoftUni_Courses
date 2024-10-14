function loadingBar(percentage){
    let barsFileld = percentage / 10;
    let emptyBars = 10 - barsFileld;

    if (percentage === 100){
        console.log("100% Complete!");
        console.log(`[${'%'.repeat(10)}]`);
    } else {
        console.log(`${percentage}% [${'%'.repeat(barsFileld)}${'.'.repeat(emptyBars)}]`);
        console.log("Still loading...");
    }
}

loadingBar(100);