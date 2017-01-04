/*
Copyright DHTMLX LTD. http://www.dhtmlx.com
To use this component please contact sales@dhtmlx.com to obtain license
*/
Scheduler.plugin(function(e){e.attachEvent("onTemplatesReady",function(){for(var c=document.body.getElementsByTagName("DIV"),b=0;b<c.length;b++){var a=c[b].className||"",a=a.split(":");if(a.length==2&&a[0]=="template"){var d='return "'+(c[b].innerHTML||"").replace(/\"/g,'\\"').replace(/[\n\r]+/g,"")+'";',d=unescape(d).replace(/\{event\.([a-z]+)\}/g,function(b,a){return'"+ev.'+a+'+"'});e.templates[a[1]]=Function("start","end","ev",d);c[b].style.display="none"}}})});
