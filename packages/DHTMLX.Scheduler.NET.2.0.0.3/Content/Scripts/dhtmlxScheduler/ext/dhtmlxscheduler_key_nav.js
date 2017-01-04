/*
Copyright DHTMLX LTD. http://www.dhtmlx.com
To use this component please contact sales@dhtmlx.com to obtain license
*/
Scheduler.plugin(function(d){(function(){var h=!1,i,e=null;d.attachEvent("onBeforeLightbox",function(){return h=!0});d.attachEvent("onAfterLightbox",function(){h=!1;return!0});d.attachEvent("onMouseMove",function(b,a){i=d.getActionData(a).date});dhtmlxEvent(document,_isOpera?"keypress":"keydown",function(b){b=b||event;if(!h){var a=window.scheduler;if(b.keyCode==37||b.keyCode==39){b.cancelBubble=!0;var d=a.date.add(a._date,b.keyCode==37?-1:1,a._mode);a.setCurrentView(d);return!0}var f=a._select_id;
if(b.ctrlKey&&b.keyCode==67){if(f)a._buffer_id=f,e=!0,a.callEvent("onEventCopied",[a.getEvent(f)]);return!0}if(b.ctrlKey&&b.keyCode==88&&f){e=!1;a._buffer_id=f;var c=a.getEvent(f);a.updateEvent(c.id);a.callEvent("onEventCut",[c])}if(b.ctrlKey&&b.keyCode==86){if(c=a.getEvent(a._buffer_id)){var j=c.end_date-c.start_date;if(e){var g=a._lame_clone(c);g.id=a.uid();g.start_date=new Date(i);g.end_date=new Date(g.start_date.valueOf()+j);a.addEvent(g);a.callEvent("onEventPasted",[e,g,c])}else{var k=a._lame_copy({},
c);c.start_date=new Date(i);c.end_date=new Date(c.start_date.valueOf()+j);a.render_view_data();a.callEvent("onEventPasted",[e,c,k]);e=!0}}return!0}}})})()});
