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
    let movies = []
    if (response.Response === "True") {
        for (var movie in response.Search) {
            movies.push(response.Search[movie])
            let currentMovie = response.Search[movie]
            let template =
                `<a href="/DetailPage/Movies/${currentMovie.Title}">
                    <h1>${currentMovie.Title}</h1>
                    <img src="${currentMovie.Poster}"/>
                </a>`
            let innerDiv = document.createElement("div")
            innerDiv.innerHTML = template
            div.appendChild(innerDiv)
        }
    }
    else {
        const response = await fetch(`${baseUrl}t=${input}${key}`).then(response => response.json())
        if (response.Response != "False") {
            let template =
                        `<a href="/DetailPage/Movies/${response.Title}">
                                <h1>${response.Title}</h1>
                                <img src="${response.Poster}"/>
                            </a>`
            let innerDiv = document.createElement("div")
            innerDiv.innerHTML = template
            div.appendChild(innerDiv)
        }
    }
    
    //title.textContent = response.Title
    //poster.src = response.Poster
    //link.setAttribute("href", `/DetailPage/Movies/` + response.Title)

    //let template =
    //    `<a asp-controller="DetailPage" asp-action="Movies" asp-route-id="${response.Title}" href="@Url.Action("Movies", "DetailPage")?itemId=${response.Title}">`

    /*div.innerHTML = template + div.innerHTML + "</a>"*/

}

document.querySelector("#searchField").addEventListener("input", search)