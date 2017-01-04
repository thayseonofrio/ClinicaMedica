/*
Copyright DHTMLX LTD. http://www.dhtmlx.com
To use this component please contact sales@dhtmlx.com to obtain license
*/
Scheduler.plugin(function(b){(function(){function f(a){var c=function(){};c.prototype=a;return c}var e=b._load;b._load=function(a,c){a=a||this._load_url;if(typeof a=="object")for(var b=f(this._loaded),d=0;d<a.length;d++)this._loaded=new b,e.call(this,a[d],c);else e.apply(this,arguments)}})()});
