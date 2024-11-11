export function railwindAddClickOutsideListener(element, dotnetHelper) {
    let isMouseDownInside = false;

    function handleMouseDown(event) {
        // Check if mousedown happened within the element
        isMouseDownInside = element.contains(event.target);
    }

    function handleMouseUp(event) {
        // Only invoke the method if mousedown started outside or mouseup finishes outside the element
        if (!isMouseDownInside && !element.contains(event.target)) {
            dotnetHelper.invokeMethodAsync('OnClickedOutside');
        }
    }

    console.log('Adding click outside listener');

    // Save the handlers so we can remove them later if needed
    element._mouseDownHandler = handleMouseDown;
    element._mouseUpHandler = handleMouseUp;

    document.addEventListener('mousedown', handleMouseDown);
    document.addEventListener('mouseup', handleMouseUp);
}

// Removes the click outside listener
export function railwindRemoveClickOutsideListener(element) {
    if (!element) {
        console.warn('Element is null or undefined, cannot remove event listeners.');
        return;
    }

    if (element._mouseDownHandler) {
        console.log('Removing mousedown listener');
        document.removeEventListener('mousedown', element._mouseDownHandler);
        delete element._mouseDownHandler;
    }

    if (element._mouseUpHandler) {
        console.log('Removing mouseup listener');
        document.removeEventListener('mouseup', element._mouseUpHandler);
        delete element._mouseUpHandler;
    }
}
