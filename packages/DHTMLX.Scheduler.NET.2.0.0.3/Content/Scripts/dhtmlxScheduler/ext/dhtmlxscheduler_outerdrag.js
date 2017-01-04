/*
Copyright DHTMLX LTD. http://www.dhtmlx.com
To use this component please contact sales@dhtmlx.com to obtain license
*/
Scheduler.plugin(function(a){a.attachEvent("onTemplatesReady",function(){var b=new dhtmlDragAndDropObject,e=b.stopDrag,c;b.stopDrag=function(a){c=a||event;return e.apply(this,arguments)};b.addDragLanding(a._els.dhx_cal_data[0],{_drag:function(g,b,e,i){if(!a.checkEvent("onBeforeExternalDragIn")||a.callEvent("onBeforeExternalDragIn",[g,b,e,i,c])){var j=a.attachEvent("onEventCreated",function(b,c){if(!a.callEvent("onExternalDragIn",[b,g,c]))this._drag_mode=this._drag_id=null,this.deleteEvent(b)});if(a.matrix&&
a.matrix[a._mode])a.dblclick_dhx_matrix_cell(c);else{var h=document.createElement("div");h.className="dhx_month_body";var d={},f;for(f in c)d[f]=c[f];d.target=d.srcElement=h;a._on_dbl_click(d)}a.detachEvent(j)}},_dragIn:function(a){return a},_dragOut:function(){return this}})})});
