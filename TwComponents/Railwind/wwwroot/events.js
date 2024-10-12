export function railwindAddClickOutsideListener(element, dotnetHelper) {
    function handleClick(event) {
        if (!element.contains(event.target)) {
            dotnetHelper.invokeMethodAsync('OnClickedOutside');
        }
    }
    
    console.log('Adding click outside listener')

    // Save the handler so we can remove it later
    element._clickOutsideHandler = handleClick;
    document.addEventListener('click', handleClick);
}

// Removes the click outside listener
export function railwindRemoveClickOutsideListener(element) {
    if (element._clickOutsideHandler) {
        console.log('removing click outside listener')
        document.removeEventListener('click', element._clickOutsideHandler);
        delete element._clickOutsideHandler;
    }
}