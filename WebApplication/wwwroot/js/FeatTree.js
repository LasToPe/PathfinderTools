function onClick_subtree(id) {
    let container = document.getElementById(id).parentElement;

    let featName = id.match(/(?!.*\|)(.+)/)[0];
    console.log(featName);

    let element = document.getElementById(id);
    let loader = element.getElementsByClassName("feat-open")[0];
    load(loader);

    $.ajax({
        url: "/FeatTree/GetChildren",
        method: "GET",
        data: { parent: featName },
        accepts: "application/json",
        success: function (result) {
            console.log(result);
            hideOtherFeats();
            createSubTree(container, id, result);
            //doneLoading(loader);
            element.removeChild(loader);
        }
    });
}

function hideOtherFeats() {

}

function load(element) {
    element.classList.remove("glyphicon");
    element.classList.remove("glyphicon-chevron-down");
    element.classList.add("loader");
}

function doneLoading(element) {
    element.classList.remove("loader");
    element.classList.add("glyphicon");
    element.classList.add("glyphicon-chevron-down");
}

function createSubTree(container, parentId, children) {
    let sub = document.createElement("div");
    sub.classList.add("col-md-12");

    for (i = 0; i < children.length; i++) {
        let child = children[i];

        let subRow = document.createElement("div");
        subRow.classList.add("row");
        subRow.classList.add("feat-tree-area");

        let div = document.createElement("div");
        div.classList.add("col-md-3");
        div.classList.add("feat-tree-block");
        div.id = parentId + "|" + child.name;
        div.onclick = function () { onClick_subtree(div.id); };

        let imageSpan = document.createElement("span");
        imageSpan.classList.add("link-img");
        let imageLink = document.createElement("a");
        imageLink.href = child.link;
        imageLink.target = "_blank";
        let image = document.createElement("img");
        image.src = "/images/link.png";
        imageLink.appendChild(image);
        imageSpan.appendChild(imageLink);

        let strong = document.createElement("strong");
        let text = document.createTextNode(child.name);
        strong.appendChild(text);

        let arrow = document.createElement("span");
        arrow.classList.add("glyphicon");
        arrow.classList.add("glyphicon-chevron-down");
        arrow.classList.add("feat-open");

        div.appendChild(imageSpan);
        div.appendChild(strong);
        div.appendChild(arrow);

        subRow.appendChild(div);
        sub.appendChild(subRow);
    }
    container.appendChild(sub);
}