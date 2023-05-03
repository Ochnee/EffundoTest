function getHeaders() {
    var headers = document.querySelectorAll("h4, h5, h6, h7, h8");
    console.log(headers.length)
    var array = new Array();
    headers.forEach(function (header) {
        if (header.id != "") {
            let headerObject = new Object();
            headerObject.title = header.innerText;
            headerObject.id = header.id;
            console.log("Header count: " + header.innerText)
            array.push(headerObject);
        }
    });
    console.log(array);
    return array;
}

