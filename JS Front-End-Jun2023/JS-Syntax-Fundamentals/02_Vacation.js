function calcTotalPrice(participants, type, day)
{
    let finalPrice = 0;
    let discountedPrice = 1;
    let pricePerNight = 0;

    if (type === "Students")
    {
        switch (day)
        {
            case "Friday":
                pricePerNight = 8.45;
                break;
            case "Saturday":
                pricePerNight = 9.80;
                break;
            case "Sunday":
                pricePerNight = 10.46;
                break;
        }

        if (participants >= 30) 
        {
            discountedPrice = 0.85;
        }
    }
    else if (type === "Business")
    {
        switch (day)
        {
            case "Friday":
                pricePerNight = 10.90;
                break;
            case "Saturday":
                pricePerNight = 15.60;
                break;
            case "Sunday":
                pricePerNight = 16.00;
                break;
        }

        if (participants >= 100) 
        {
            discountedPrice = (participants - 10) / participants;
        }
    }
    else if (type === "Regular")
    {
        switch (day)
        {
            case "Friday":
                pricePerNight = 15.00;
                break;
            case "Saturday":
                pricePerNight = 20.00;
                break;
            case "Sunday":
                pricePerNight = 22.50;
                break;
        }

        if (participants >= 10 && participants <= 20) 
        {
            discountedPrice = 0.95;
        }
    }

    finalPrice = participants * pricePerNight * discountedPrice;

    console.log(`Total price: ${finalPrice.toFixed(2)}`);
}

//calcTotalPrice(40, "Regular", "Saturday")