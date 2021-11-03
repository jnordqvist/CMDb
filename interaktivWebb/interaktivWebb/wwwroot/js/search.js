////let title = document.querySelector("#previewTitle");
////let poster = document.querySelector("#previewImg");
/*let link = document.querySelector("#searchLink");*/
let searching = false
let div = document.querySelector("#previewSearch");
const baseUrl = "https://www.omdbapi.com/?";
const key = "&apikey=f44c5f0a";

let magnifyingGlass = document.querySelector("#search")

function openSearch() {
    let container = document.querySelector("#searchContainer")
    container.id = 'searchContainerExpanded'
    document.querySelector("#search").src = "/images/close.svg"
    document.querySelector("#searchField").focus()
    searching = true
}

function closeSearch() {
    let container = document.querySelector("#searchContainerExpanded")
    container.id = 'searchContainer'
    document.querySelector("#search").src = "/images/magnifyingGlass.svg"
    searching = false
}

function toggleSearch() {
    let x = window.matchMedia("(max-width : 999px)")
    if (x.matches) {
        if (searching) {
            return closeSearch()
        }
        else {
            return openSearch()
        }
    }
}

magnifyingGlass.addEventListener("click", toggleSearch)

async function search() {
    div.innerHTML = ''
    let input = document.querySelector("#searchField").value;
    const response = await fetch(`${baseUrl}s=${input}${key}`).then(response => response.json())

    //om search-endpoint inte ger något response körs en get by title istället
    if (response.Response === "True") {
        for (var movie in response.Search) {
            let currentMovie = response.Search[movie]

            if (currentMovie.Poster == "N/A") {
                currentMovie.Poster = "/images/cmdb.png"
            }
            let template =
                `<a href="/DetailPage/Movies/${currentMovie.imdbID}">
                    <img src="${currentMovie.Poster}"/>
                </a>
                <div class="moviePreviewTextContainer">
                    <a href="/DetailPage/Movies/${currentMovie.imdbID}">
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
            if (response.Poster == "N/A") {
                response.Poster = "/images/cmdb.png"
            }
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
        div.style.display = "none"
}

let searchField = document.querySelector("#searchField")
searchField.addEventListener("blur", hideSearchSuggestions)
searchField.addEventListener("focus", showSearchSuggestions)
searchField.addEventListener("input", search)
div.addEventListener("click", showSearchSuggestions)