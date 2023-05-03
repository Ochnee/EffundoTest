window.scrollToElementId = (elementId) => {
    console.info('scrolling to element', elementId);
    var element = document.getElementById(elementId);
    if (!element) {
        console.warn('element was not found', elementId);
        return false;
    }
    element.scrollIntoView({ behavior: "smooth", block: "center", inline: "center" });
    return true;
}