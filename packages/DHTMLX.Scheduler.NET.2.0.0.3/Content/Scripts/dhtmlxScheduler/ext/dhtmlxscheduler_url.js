/*
Copyright DHTMLX LTD. http://www.dhtmlx.com
To use this component please contact sales@dhtmlx.com to obtain license
*/
Scheduler.plugin(function(b){b.attachEvent("onTemplatesReady",function(){var e=!0,f=b.date.str_to_date("%Y-%m-%d"),i=b.date.date_to_str("%Y-%m-%d");b.attachEvent("onBeforeViewChange",function(b,j,g,k){if(e){e=!1;for(var a={},h=(document.location.hash||"").replace("#","").split(","),c=0;c<h.length;c++){var d=h[c].split("=");d.length==2&&(a[d[0]]=d[1])}if(a.date||a.mode){try{this.setCurrentView(a.date?f(a.date):null,a.mode||null)}catch(m){this.setCurrentView(a.date?f(a.date):null,g)}return!1}}var l=
"#date="+i(k||j)+",mode="+(g||b);document.location.hash=l;return!0})})});
