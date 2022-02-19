/*window.addEventListener("scroll", function () {
    //for (let i = 0; i < document.getElementsByTagName("section").length; i++) {}
      // Add class 'active' to section when near top of viewport
      if (
        document.getElementsByClassName("home")[0].getBoundingClientRect().bottom >=
          0 
          &&
        document
          .querySelector("section")
          .getBoundingClientRect().bottom >= 0
          //window.innerHeight
           /*&&
        document.getElementsByTagName("section")[i].getBoundingClientRect()
          .left >= 0
      ) {
        document.querySelectorAll('header'
        )[0].style.cssText =
          "  background: white;color:black;";
          document.querySelectorAll(
            '.navbar'
          )[0].style.cssText =
            "  background: white;color: black;";
        //document.getElementsByTagName("section")[i].className =
          //"your-active-class";
      } else {
        /*document
          .getElementsByTagName("section")
          [i].classList.remove("your-active-class");
        document.querySelectorAll(
          '[href ="#section' + (i + 1) + '"]'
        )[0].style.cssText = "color:black; background:white";
      }
    
  });*/
  window.addEventListener("load",function(){
    getLocation();

  })

  var x = document.getElementById("demo");

function getLocation() {
    if (navigator.geolocation) {
      navigator.geolocation.getCurrentPosition(showPosition);
    } else { 
      x.innerHTML = "Geolocation is not supported by this browser.";
    }
  }
  var y;
  function showPosition(position) {
    console.log(false);
    let baseURL2 = `https://api.openweathermap.org/data/2.5/weather?lat=${position.coords.latitude}&lon=${position.coords.longitude}&appid=30cb3161f22013948834e0d70bc3ce71&units=metric`;
    
    fetch(baseURL2)
    .then(response => response.json())
    .then(data =>{
      fetch(`https://api.weatherapi.com/v1/current.json?key=ac1763cd50fd42cd9fe131850210912&q=${data.name}`)
    .then(response => response.json())
    .then(data =>console.log(data));
    })
    
    
  }
 
async function updated(y) {
  document.querySelector(".weather").innerText=`temp :${y.main.temp}C`;
  console.log(true);
  }