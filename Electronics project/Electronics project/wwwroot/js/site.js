// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


var burger = document.querySelector(".fa-bars");
var burgerLinks = document.querySelector(".nav-links-con-burger");

burger.addEventListener("click", menuShow);

function menuShow() {
    burgerLinks.classList.toggle("show");
}

function menuAutoHide() {
    var screenWidth = window.innerWidth;

    if (screenWidth > 600) {
        burgerLinks.classList.remove("show");
    }
}

window.addEventListener("resize", menuAutoHide);

var gif = document.getElementById('gif');

function checkGif() {
    if (gif.src = "images/ilustration.gif" === null) {
        console.log("No gif found");
        return
    }
    gif.src = "images/ilustration.gif?a=" + Math.random();
}

checkGif();


