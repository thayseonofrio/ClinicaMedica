/*
Copyright DHTMLX LTD. http://www.dhtmlx.com
To use this component please contact sales@dhtmlx.com to obtain license
*/
Scheduler.plugin(function(a){a.config.active_link_view="day";a.attachEvent("onTemplatesReady",function(){var e=a.date.str_to_date(a.config.api_date),b=a.date.date_to_str(a.config.api_date),f=a.templates.month_day;a.templates.month_day=function(a){return"<a jump_to='"+b(a)+"' href='#'>"+f(a)+"</a>"};var g=a.templates.week_scale_date;a.templates.week_scale_date=function(a){return"<a jump_to='"+b(a)+"' href='#'>"+g(a)+"</a>"};dhtmlxEvent(this._obj,"click",function(c){var b=c.target||event.srcElement,
d=b.getAttribute("jump_to");if(d)return a.setCurrentView(e(d),a.config.active_link_view),c&&c.preventDefault&&c.preventDefault(),!1})})});
