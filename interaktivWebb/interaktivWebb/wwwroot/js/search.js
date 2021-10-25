let title = document.querySelector("#previewTitle");
let poster = document.querySelector("#previewImg");

const baseUrl = "https://www.omdbapi.com/?";
const key = "&apikey=f44c5f0a";


async function search() {
    
    let input = document.querySelector("#searchField").value;
    console.log(input)
     const response = await fetch(`${baseUrl}t=${input}${key}`).then(response => response.json())
    console.log(response)
    title.textContent = response.Title
    poster.src = response.Poster
    console.log(response.Title)
}

document.querySelector("#searchField").addEventListener("input", search)