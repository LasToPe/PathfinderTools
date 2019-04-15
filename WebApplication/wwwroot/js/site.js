// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function onClick_subtree(id) {
    let parent = document.getElementById(id).parentElement;

    $.ajax({
        url: "/FeatTree/GetChildren",
        method: "GET",
        data: { parent: id },
        accepts: "application/json",
        success: function (result) {
            console.log(result);
            hideOtherFeats();
            createSubTree(parent, result);
        }
    });
}

function hideOtherFeats() {

}

function createSubTree(parent, children) {
    let subRow = document.createElement("div");
    subRow.classList.add("row");
    subRow.classList.add("feat-tree-area");

    for (i = 0; i < children.length; i++) {
        let child = children[i];

        let div = document.createElement("div");
        div.classList.add("col-md-3");
        div.classList.add("feat-tree-block");
        div.id = child.name;
        div.onclick = "onClick_subtree(this.id)";

        let strong = document.createElement("strong");
        let text = document.createTextNode(child.name);
        strong.appendChild(text);

        let imageSpan = document.createElement("span");
        imageSpan.classList.add("link-img");
        let imageLink = document.createElement("a");
        imageLink.href = child.link;
        imageLink.target = "_blank";
        let image = document.createElement("img");
        image.src = "/images/link.png";
        imageLink.appendChild(image);
        imageSpan.appendChild(imageLink);

        div.appendChild(strong);
        div.appendChild(imageSpan);

        subRow.appendChild(div);
    }

    parent.appendChild(subRow);
}