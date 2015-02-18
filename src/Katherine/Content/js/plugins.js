//Replace no-js class with js class.
var h = document.documentElement;
h.className = h.className.replace(/\bno-js\b/g, '') + ' js ';

// Avoid `console` errors in browsers that lack a console.
(function () {
  var method;
  var noop = function () { };
  var methods = [
      'assert', 'clear', 'count', 'debug', 'dir', 'dirxml', 'error',
      'exception', 'group', 'groupCollapsed', 'groupEnd', 'info', 'log',
      'markTimeline', 'profile', 'profileEnd', 'table', 'time', 'timeEnd',
      'timeline', 'timelineEnd', 'timeStamp', 'trace', 'warn'
  ];
  var length = methods.length;
  var console = (window.console = window.console || {});

  while (length--) {
    method = methods[length];

    // Only stub undefined methods.
    if (!console[method]) {
      console[method] = noop;
    }
  }
}());

// String.IsNullOrEmpty implementation
String.IsNullOrEmpty = function (value) {
  if (value) {
    if (typeof (value) == 'string') {
      if (value.length > 0)
        return false;
    }
    if (value != null)
      return false;
  }
  return true;
}

// Place any jQuery/helper plugins in here.