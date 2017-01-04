/*
Copyright DHTMLX LTD. http://www.dhtmlx.com
To use this component please contact sales@dhtmlx.com to obtain license
*/
Scheduler.plugin(function(h){h.form_blocks.multiselect={render:function(d){for(var a="<div class='dhx_multi_select_"+d.name+"' style='overflow: auto; height: "+d.height+"px; position: relative;' >",b=0;b<d.options.length;b++)a+="<label><input type='checkbox' value='"+d.options[b].key+"'/>"+d.options[b].label+"</label>",convertStringToBoolean(d.vertical)&&(a+="<br/>");a+="</div>";return a},set_value:function(d,a,b,c){function i(b){for(var c=d.getElementsByTagName("input"),a=0;a<c.length;a++)c[a].checked=
!!b[c[a].value]}for(var f=d.getElementsByTagName("input"),e=0;e<f.length;e++)f[e].checked=!1;f=[];if(b[c.map_to]){for(var j=b[c.map_to].split(","),e=0;e<j.length;e++)f[j[e]]=!0;i(f)}else if(!h._new_event&&c.script_url){var g=document.createElement("div");g.className="dhx_loading";g.style.cssText="position: absolute; top: 40%; left: 40%;";d.appendChild(g);dhtmlxAjax.get(c.script_url+"?dhx_crosslink_"+c.map_to+"="+b.id+"&uid="+h.uid(),function(b){for(var a=b.doXPath("//data/item"),e=[],f=0;f<a.length;f++)e[a[f].getAttribute(c.map_to)]=
!0;i(e);d.removeChild(g)})}},get_value:function(d){for(var a=[],b=d.getElementsByTagName("input"),c=0;c<b.length;c++)b[c].checked&&a.push(b[c].value);return a.join(",")},focus:function(){}}});
