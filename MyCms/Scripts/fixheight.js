//fixheight

jQuery.fn.vjustify = function () {
    var maxHeight = 0;
    this.each(function () {
        if (this.offsetHeight > maxHeight) { maxHeight = this.offsetHeight; }
    });
    this.each(function () {
        jQuery(this).height(maxHeight + "px");
        if (this.offsetHeight > maxHeight) {
            jQuery(this).height((maxHeight - (this.offsetHeight - maxHeight)) + "px");
        }
    });
};

function runOnLoad(f) {
    if (runOnLoad.loaded) f();    // If already loaded, just invoke f() now.
    else runOnLoad.funcs.push(f); // Otherwise, store it for later
}

runOnLoad.funcs = []; // The array of functions to call when the document loads
runOnLoad.loaded = false; // The functions have not been run yet.

runOnLoad.run = function () {
    if (runOnLoad.loaded) return;  // If we've already run, do nothing

    for (var i = 0; i < runOnLoad.funcs.length; i++) {
        try { runOnLoad.funcs[i](); }
        catch (e) { / An exception in one function shouldn't stop the rest / }
    }

    runOnLoad.loaded = true; // Remember that we've already run once.

    delete runOnLoad.funcs;  // But don't remember the functions themselves.
    delete runOnLoad.run;    // And forget about this function too!
};

// Register runOnLoad.run() as the onload event handler for the window
if (window.addEventListener)
    window.addEventListener("load", runOnLoad.run, false);
else if (window.attachEvent) window.attachEvent("onload", runOnLoad.run);
else window.onload = runOnLoad.run;

runOnLoad(function () {
    jQuery(".fixheight").vjustify();
    jQuery(".fixheight1").vjustify();
    jQuery(".fixheight2").vjustify();
    jQuery(".fixheight3").vjustify();
});
