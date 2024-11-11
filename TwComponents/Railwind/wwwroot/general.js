export function copyTextToClipboard(text) {
    navigator.clipboard.writeText(text).then(function() {
        console.log('Successfully copied to clipboard');
    }).catch(function(err) {
        console.error('Could not copy text: ', err);
    });
}