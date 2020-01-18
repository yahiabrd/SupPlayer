// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function changeLight() {
    var source = document.getElementById("light").src;
    var splitSource = source.split("/");
    var lightImg = splitSource[4];
    if (lightImg == "light.png") {
        //config pour dark mode
        document.getElementById("light").src = "/images/dark.png";
        document.body.classList.toggle("darkLight");
    } else {
        //config pour light mode
        document.getElementById("light").src = "/images/light.png";
        document.body.classList.toggle("darkLight");
    }
}