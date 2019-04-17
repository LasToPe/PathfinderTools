document.onreadystatechange = function () {
    if (document.readyState === "complete") {
        //search enter
        document.getElementById("treeSearchInput").addEventListener("keypress", function (event) {
            if (event.keyCode === 13) {
                event.preventDefault();
                searchTree();
            }
        });
    }
};

function onClick_subtree(id) {
    let container = document.getElementById(id).parentElement;

    let featName = id.match(/(?!.*\|)(.+)/)[0];

    let element = document.getElementById(id);
    let loader = element.getElementsByClassName("feat-open")[0];
    load(loader);

    $.ajax({
        url: "/FeatTree/GetChildren",
        method: "GET",
        data: { parent: featName },
        accepts: "application/json",
        success: function (result) {
            createSubTree(container, id, result);
            element.removeChild(loader);
        }
    });
}

function searchTree() {
    let searchloader = document.createElement("div");
    searchloader.classList.add("loader");
    searchloader.classList.add("search-loader");
    let searchdiv = document.getElementsByClassName("form-inline")[0];
    searchdiv.appendChild(searchloader);

    let input = document.getElementById("treeSearchInput").value;

    if (input === "") {
        $(".hidden").removeClass("hidden");
        searchdiv.removeChild(searchloader);
        return;
    }
    $.ajax({
        url: "/FeatTree/TreeSearch",
        method: "GET",
        data: { input: input },
        accepts: "application/json",
        success: function (result) {
            $(".feat-tree-block").addClass("hidden");
            for (i = 0; i < result.length; i++) {
                let element = document.getElementById(result[i]);
                element.classList.remove("hidden");
            }
            searchdiv.removeChild(searchloader);
        }
    });
}

function load(element) {
    element.classList.remove("glyphicon");
    element.classList.remove("glyphicon-chevron-down");
    element.classList.add("loader");
}

function createSubTree(container, parentId, children) {
    let sub = document.createElement("div");
    sub.classList.add("col-md-12");

    if (children.length < 1) {
        sub.style.marginLeft = "15px";
        let text = document.createTextNode("No feats listing " + parentId + " as a prerequisite found");
        sub.appendChild(text);
        container.appendChild(sub);
        return;
    }

    for (i = 0; i < children.length; i++) {
        let child = children[i];

        let subRow = document.createElement("div");
        subRow.classList.add("row");
        subRow.classList.add("feat-tree-area");

        let div = document.createElement("div");
        div.classList.add("col-md-3");
        div.classList.add("feat-tree-block");
        div.id = parentId + "|" + child.name;

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
        arrow.onclick = function () { onClick_subtree(div.id); };

        div.appendChild(imageSpan);
        div.appendChild(strong);
        div.appendChild(arrow);

        subRow.appendChild(div);
        sub.appendChild(subRow);
    }
    container.appendChild(sub);
}