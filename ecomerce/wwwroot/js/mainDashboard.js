window.addEventListener("load", function () {
    getCoordintes();



})



function getCoordintes() {
    navigator.geolocation.getCurrentPosition(function (position) {
        //let lat = position.coords.latitude;
        //let long = position.coords.longitude;
        //console.log(lat);
        getCity(position);
        displayLocation(position.coords.latitude, position.coords.longitude)
    })


    //var options = {
    //    enableHighAccuracy: true,
    //    timeout: 5000,
    //    maximumAge: 0
    //};

    //function success(pos) {
    //    var crd = pos.coords;
    //    var lat = crd.latitude.toString();
    //    var lng = crd.longitude.toString();
    //    var coordinates = [lat, lng];
    //    console.log(`Latitude: ${lat}, Longitude: ${lng}`);
    //    getCity(coordinates)
    //    return;

    //}

    //function error(err) {
    //    console.warn(`ERROR(${err.code}): ${err.message}`);
    //}

    //navigator.geolocation.getCurrentPosition(success, error, options);
}
function getCity(coordinates) {
    var xhr = new XMLHttpRequest();
    var lat = coordinates.coords.latitude;
    var lng = coordinates.coords.longitude;

    // Paste your LocationIQ token below.
    xhr.open('GET', "https://us1.locationiq.com/v1/reverse.php?key=pk.b3e3351d22c0f09417b6d9c71839b1b8&lat=" +
        lat + "&lon=" + lng + "&format=json", true);
    xhr.send();
    xhr.onreadystatechange = processRequest;
    xhr.addEventListener("readystatechange", processRequest, false);

    function processRequest(e) {
        if (xhr.readyState == 4 && xhr.status == 200) {
            var response = JSON.parse(xhr.responseText);
            var city = response.address.city;
            console.log(city);
            getLocation(city);
            return;
        }
    }
}
// Step 2: Get city name
//function getCity(position) {
//    console.log("hi");
//    console.log(position.coords.latitude);
//    console.log(position.coords.longitude);
//    var lat = position.coords.latitude;
//    var lng = position.coords.longitude;
//    fetch(`http://api.positionstack.com/v1/reverse?access_key=yqpuUHweaX01WBy0EtTC44k7sQYjzLQC&query=${lat},${lng}`)
//        .then(response => response.json())
//        .then(data => getLocation(data.data[0].region));

//}





function getLocation(city) {
    fetch(`https://api.weatherapi.com/v1/current.json?key=ac1763cd50fd42cd9fe131850210912&q=${city}`)
        .then(response => response.json())
        .then(data => updated(data));
}
function updated(data) {
    document.querySelector(".weather").innerHTML = `
        
        <div style=" display: flex;"> 
        <img src="${data.current.condition.icon}" alt="">
        <div style=" display: flex; flex-direction: column;">
           <p>${data.current.temp_c}ْC</p>
           <p>${data.current.condition.text}</p>
        </div>
        </div>
        <div style=" display: flex; justify-content:space-around;">
        <div class="temp" style=" display: flex;flex-direction: column;">
        <p>% ${data.current.humidity}:رطوبة</p> 
        <p> ${data.current.last_updated}: اخر تحديث</p>
        
        </div>
        <div class="temp" style=" display: flex;flex-direction: column;">
        <p>${data.current.pressure_mb}mb :الضغط</p>
        <p> ${data.current.wind_degree}${data.current.wind_dir}:الرياح</p>
        </div>
        </div>
        `;
    console.log(true);
}