/*
Copyright DHTMLX LTD. http://www.dhtmlx.com
To use this component please contact sales@dhtmlx.com to obtain license
*/
Scheduler.plugin(function(f){(function(){function h(e,b,a){var c=e+"="+a+(b?"; "+b:"");document.cookie=c}function i(e){var b=e+"=";if(document.cookie.length>0){var a=document.cookie.indexOf(b);if(a!=-1){a+=b.length;var c=document.cookie.indexOf(";",a);if(c==-1)c=document.cookie.length;return document.cookie.substring(a,c)}}return""}var g=!0;f.attachEvent("onBeforeViewChange",function(e,b,a,c){if(g){g=!1;var d=i("scheduler_settings");if(d)return d=unescape(d).split("@"),d[0]=this.templates.xml_date(d[0]),
window.setTimeout(function(){f.setCurrentView(d[0],d[1])},1),!1}var j=escape(this.templates.xml_format(c||b)+"@"+(a||e));h("scheduler_settings","expires=Sun, 31 Jan 9999 22:00:00 GMT",j);return!0})})()});
