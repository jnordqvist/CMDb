// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

const dotNetCall = (dotNetHelper) => {
    var movie = dotNetHelper.InvokeMethodAsync("{interaktivWebb}", "{helloMovie}")

    document.getElementById("like").innerHTML = movie.numberOfLikes
    console.log("hello")
}


document.getElementsByClassName("likeBtn")[0].addEventListener("click", dotNetCall)

