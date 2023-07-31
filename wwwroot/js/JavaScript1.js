function ShowBessari() {
    var id = document.getElementById("BessariImage");
    if (id.style.display == "none") {
        {
            document.getElementById("BessariImage").style.display = "inline-block";
            document.getElementById("HalaviiImage").style.display = "none";
            document.getElementById("BreadImage").style.display = "none";
            document.getElementById("ParveiImage").style.display = "none";
            document.getElementById("VegetableImage").style.display = "none";
            document.getElementById("FruitImage").style.display = "none";

        }
    }
    else
        document.getElementById("BessariImage").style.display = "none";
}
function ShowFruit() {
    var id = document.getElementById("FruitImage");
    if (id.style.display == "none") {
        {
            document.getElementById("FruitImage").style.display = "inline-block";
            document.getElementById("HalaviiImage").style.display = "none";
            document.getElementById("BreadImage").style.display = "none";
            document.getElementById("ParveiImage").style.display = "none";
            document.getElementById("VegetableImage").style.display = "none";
            document.getElementById("BessariImage").style.display = "none";
        }
    }
    else
        document.getElementById("BessariImage").style.display = "none";
}
function ShowBread() {
    var id = document.getElementById("BreadImage");
    if (id.style.display == "none") {
        {
            document.getElementById("BreadImage").style.display = "inline-block ";
            document.getElementById("HalaviiImage").style.display = "none";
            document.getElementById("ParveiImage").style.display = "none";
            document.getElementById("BessariImage").style.display = "none";
            document.getElementById("VegetableImage").style.display = "none";
            document.getElementById("FruitImage").style.display = "none";

        }
    }
    else
        document.getElementById("BreadImage").style.display = "none";
}

function ShowVegetable() {
    var id = document.getElementById("VegetableImage");
    if (id.style.display == "none") {
        {
            document.getElementById("VegetableImage").style.display = "inline-block ";
            document.getElementById("HalaviiImage").style.display = "none";
            document.getElementById("ParveiImage").style.display = "none";
            document.getElementById("BessariImage").style.display = "none";
            document.getElementById("BreadImage").style.display = "none";
            document.getElementById("FruitImage").style.display = "none";

        }
    }
    else
        document.getElementById("VegetableImage").style.display = "none";
}

function ShowHalavi() {
    var id = document.getElementById("HalaviiImage");
    if (id.style.display == "none") {
        document.getElementById("HalaviiImage").style.display = "inline-block";
        document.getElementById("BessariImage").style.display = "none";
        document.getElementById("BreadImage").style.display = "none";
        document.getElementById("ParveiImage").style.display = "none";
        document.getElementById("VegetableImage").style.display = "none";
        document.getElementById("FruitImage").style.display = "none";

    }
    else
        document.getElementById("HalaviiImage").style.display = "none";
}
function ShowParve() {
    var id = document.getElementById("ParveiImage");
    if (id.style.display == "none") {
        document.getElementById("ParveiImage").style.display = "inline-block";
        document.getElementById("HalaviiImage").style.display = "none";
        document.getElementById("BessariImage").style.display = "none";
        document.getElementById("BreadImage").style.display = "none";
        document.getElementById("VegetableImage").style.display = "none";
        document.getElementById("FruitImage").style.display = "none";

    }
    else
        document.getElementById("ParveiImage").style.display = "none";
}

function showTheMenu() {

    var id = document.getElementById("ShowMenu");
    if (id.style.display == "none")
        document.getElementById("ShowMenu").style.display = "inline-block";
    else
        document.getElementById("ShowMenu").style.display = "none";


}

function searchMsg() {
    var input = document.getElementById("searchM");
    var inputResult = input.value;
    var url = "https://localhost:44319/Manager/searchMessage?str=" + inputResult;
    window.location.href = url;
}

function search() {
    var input = document.getElementById("search1");
    var inputResult = input.value;
    var url = "https://localhost:44319/Manager/Search?name=" + inputResult;
    window.location.href = url;
}

