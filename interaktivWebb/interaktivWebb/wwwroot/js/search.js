////let title = document.querySelector("#previewTitle");
////let poster = document.querySelector("#previewImg");
/*let link = document.querySelector("#searchLink");*/

let div = document.querySelector("#previewSearch");
const baseUrl = "https://www.omdbapi.com/?";
const key = "&apikey=f44c5f0a";


async function search() {
    div.innerHTML = ''
    let input = document.querySelector("#searchField").value;
    const response = await fetch(`${baseUrl}s=${input}${key}`).then(response => response.json())
    console.log(response)
    if (response.Response === "True") {
        for (var movie in response.Search) {
            let currentMovie = response.Search[movie]
            let template =
                `<a href="/DetailPage/Movies/${currentMovie.Title}">
                    <img src="${currentMovie.Poster}"/>
                </a>
                <div class="moviePreviewTextContainer">
                <a href="/DetailPage/Movies/${currentMovie.Title}">
                    <h1>${currentMovie.Title}</h1>
                </a>
                <h2>(${currentMovie.Year})</h2>
                </div>
                `
            let innerDiv = document.createElement("div")
            innerDiv.id = "moviePreviewContainer"
            innerDiv.innerHTML = template
            div.appendChild(innerDiv)
        }
    }
    else {
        const response = await fetch(`${baseUrl}t=${input}${key}`).then(response => response.json())
        if (response.Response != "False") {
            let template =
                        `<a href="/DetailPage/Movies/${response.Title}">
                                <img src="${response.Poster}"/>
                         </a>
                        <div class="moviePreviewTextContainer">
                         <a href="/DetailPage/Movies/${response.Title}">
                                <h1>${response.Title}</h1>
                         </a>
                         <h2>(${response.Year})</h2>
                        </div>
                        `
                         
            let innerDiv = document.createElement("div")
            innerDiv.id = "moviePreviewContainer"
            innerDiv.innerHTML = template
            div.appendChild(innerDiv)
        }
    }
}

const showSearchSuggestions = () => {
    div.style.display = "flex"
}

const hideSearchSuggestions = () => {
    setTimeout(function () {
        div.style.display = "none"
    },80)
}

let searchField = document.querySelector("#searchField")
searchField.addEventListener("blur", hideSearchSuggestions)
searchField.addEventListener("focus", showSearchSuggestions)
searchField.addEventListener("input", search)