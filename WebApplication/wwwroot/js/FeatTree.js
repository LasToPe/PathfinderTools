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

function onClick_subtree(arrowId) {
    let arrow = $("[id='" + arrowId + "']");
    let element = arrow.parents(".feat-tree-area").first();
    let featName = arrow.siblings("strong").first().text();

    load(arrow);

    $.ajax({
        url: "/FeatTree/GetChildren",
        method: "GET",
        data: { parent: featName },
        accepts: "application/json",
        success: function (result) {
            createSubTree(element, element.id, featName, result);
            doneLoading(arrow);
        }
    });
}

function load(element) {
    element.removeClass("glyphicon");
    element.removeClass("glyphicon-chevron-down");
    element.addClass("loader");
}

function doneLoading(element) {
    element.removeClass("loader");
    //element.addClass("glyphicon");
    //element.addClass("glyphicon-chevron-up");
    //element.onclick = new onclick for removing child elements
    element.remove();
}

function createSubTree(container, parentId, parentName, children) {
    let sub = document.createElement("div");
    sub.classList.add("col-md-12");

    if (children.length < 1) {
        sub.style.marginLeft = "15px";
        let textspan = document.createElement("span");
        textspan.classList.add("feat-tree-text-span");
        let text = document.createTextNode("No feats listing " + parentName + " as a prerequisite found");
        textspan.append(text);
        sub.append(textspan);
        container.append(sub);
        return;
    }

    for (i = 0; i < children.length; i++) {
        let child = children[i];

        let subRow = document.createElement("div");
        subRow.classList.add("row");
        subRow.classList.add("feat-tree-area");
        subRow.id = parentId + "_" + child.name.replace(/\'/, "");

        let div = document.createElement("div");
        div.classList.add("col-md-3");
        div.classList.add("feat-tree-block");

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
        arrow.id = child.name + "_arrow";
        arrow.classList.add("glyphicon");
        arrow.classList.add("glyphicon-chevron-down");
        arrow.classList.add("feat-arrow");
        arrow.onclick = function () { onClick_subtree(arrow.id); };

        div.appendChild(imageSpan);
        div.appendChild(strong);
        div.appendChild(arrow);

        subRow.appendChild(div);
        sub.appendChild(subRow);
    }
    container.append(sub);
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
            try {
                $(".feat-tree-area").addClass("hidden");
                $(".feat-tree-text-span").addClass("hidden");
                for (i = 0; i < result.length; i++) {
                    let id = result[i].name.replace(/\'/, "");
                    // handle first level
                    let element = $("[id='"+id+"']")[0];
                    
                    if (element !== undefined) {
                        element.classList.remove("hidden");
                        $("[id='" + element.id + "']").parents().removeClass("hidden");
                        $("[id='" + element.id + "']").find("*").removeClass("hidden");
                        continue;
                    }
                    // handle based on first prerequisite
                    let req = result[i].req.name.replace(/\'/, "");
                    element = $("[id='" + req + "']")[0];
                    if (element !== undefined) {
                        element.classList.remove("hidden");
                        $("[id='" + element.id + "']").parents().removeClass("hidden");
                        $("[id='" + element.id + "']").find("*").removeClass("hidden");
                        continue;
                    }
                }
                searchdiv.removeChild(searchloader);
            }
            catch (error) {
                searchdiv.removeChild(searchloader);
                throw error;
            }
        }
    });
}