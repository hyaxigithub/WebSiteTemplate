function in_array(array, val) {
    for (var i = 0; i < array.length; i++) {
        if (array[i] === val) {
            return true;
        }
    }
    return false;
}
function removeByValue(arr, val) {
    for (var i = 0; i < arr.length; i++) {
        if (arr[i] == val) {
            arr.splice(i, 1);
            break;
        }
    }
}