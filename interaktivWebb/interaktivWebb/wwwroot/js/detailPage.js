// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

//const dotNetCall = (dotNetHelper) => {
//    var movie = dotNetHelper.InvokeMethodAsync("{interaktivWebb}", "{helloMovie}")

//    document.getElementById("like").innerHTML = movie.numberOfLikes
//    console.log("hello")
//}https://grupp9.dsvkurs.miun.se/api/Movie/tt0120201/like

const baseUrlCmdb = 'https://grupp9.dsvkurs.miun.se/api/Movie'

async function likeMovie() {
    document.querySelector("#likeBtn").disabled = true
    const id = document.querySelector("#likeBtn").value
    const response = await fetch(`${baseUrlCmdb}/${id}/like`).then(response => response.json())

    document.querySelector(".likes").childNodes[1].textContent = response.numberOfLikes

    changeCircle(response)

    document.querySelector("#likeBtn").disabled = false
}

async function dislikeMovie() {
    document.querySelector("#dislikeBtn").disabled = true
    const id = document.querySelector("#likeBtn").value
    const response = await fetch(`${baseUrlCmdb}/${id}/dislike`).then(response => response.json())

    document.querySelector(".dislikes").childNodes[1].textContent = response.numberOfDislikes

    changeCircle(response)
    document.querySelector("#dislikeBtn").disabled = false
}

function changeCircle(response) {
    let circle = document.querySelector(".circle")
    let percentage = (response.numberOfLikes / (response.numberOfLikes + response.numberOfDislikes)) * 100
    let roundedPercentage = Math.floor(percentage)
    circle.style.strokeDasharray = `${percentage}, 100`
    let text = document.querySelector(".percentage")
    text.innerHTML = `${roundedPercentage}%`
}

document.querySelector("#likeBtn").addEventListener("click", likeMovie)
document.querySelector("#dislikeBtn").addEventListener("click", dislikeMovie)


