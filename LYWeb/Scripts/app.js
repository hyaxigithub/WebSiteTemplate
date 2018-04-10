/*! AdminLTE app.js
 * ================
 * 这是AdminLTE的主要js应用文件   
 * 应包含在所有页面中。它控制一些布局 
 * 选择和执行adminlte专有插件。 
 *
 * @作者  Almsaeed Studio
 * @支持 <http://www.almsaeedstudio.com>
 * @Email   <support@almsaeedstudio.com>
 * @版本 2.3.5
 * @许可证 MIT <http://opensource.org/licenses/MIT>
 */

//确保jQuery已经加载在app.js 
if (typeof jQuery === "undefined") {
  throw new Error("AdminLTE requires jQuery");
}

/* AdminLTE
 *
 * @类型 对象
 * @描述 $.AdminLTE 是这个模板app的主要对象.
 *      它用于实现与模板相关的函数和选项. 
 *      保持包裹在一个对象的一切防止与其他插件的冲突，是一个更好的方式来组织我们的代码的方法。  */
$.AdminLTE = {};

/* --------------------
 * - AdminLTE 选项 -
 * --------------------
 * 修改这些选项以满足您的实现
 */
$.AdminLTE.options = {
  //添加slimscroll到导航栏菜单
  //这需要你加载slimscroll插件 
  //在每个页面app.js加载之前
  navbarMenuSlimscroll: true,
  navbarMenuSlimscrollWidth: "3px", //滚动条的宽度
  navbarMenuHeight: "200px", //内部菜单的高度
  //一般的动画速度用JS animated方法(实现)例如盒装、折叠/展开 and
  //侧边栏控件向上向下滑动. 这个选项接受一个整毫秒数、'fast'、'normal'或'slow'
  animationSpeed: 'fast',
  //侧边栏菜单切换按钮选择器
  sidebarToggleSelector: "[data-toggle='offcanvas']",
  //激活 sidebar push 菜单
  sidebarPushMenu: true,
  //如果固定布局设置激活侧边栏slimscroll（需要slimscroll插件）
  sidebarSlimScroll: true,
  //使侧边栏以悬浮效果展开迷你侧边栏
  //This option is forced to true if both the fixed layout and sidebar mini are used together
  //如果同时使用固定布局和迷你侧边栏这个选项被迫为true
  sidebarExpandOnHover: false,
  //BoxRefresh Plugin
  //BoxRefresh插件
  enableBoxRefresh: true,
  //Bootstrap.js tooltip
  //Bootstrap.js 工具提示
  enableBSToppltip: true,
  BSTooltipSelector: "[data-toggle='tooltip']",
  //Enable Fast Click. Fastclick.js creates a more native touch experience with touch devices. 
  //启用快速点击。Fastclick.js在触摸设备上创建更多原生触摸体验
  //If you choose to enable the plugin, make sure you load the script before AdminLTE's app.js
  //如果您选择启用插件，确保你加载 app.js脚本之前加载adminlte
  enableFastclick: false,
  //Control Sidebar Options
  //控制侧边栏选项 
  enableControlSidebar: true,
  controlSidebarOptions: {
    //Which button should trigger the open/close event
    //哪个按钮应该触发打开/关闭事件 
    toggleBtnSelector: "[data-toggle='control-sidebar']",
    //The sidebar selector
    //侧边栏选择器
    selector: ".control-sidebar",
    //Enable slide over content
    //启用幻灯片内容
    slide: true
  },
  //Box Widget Plugin. Enable this plugin to allow boxes to be collapsed and/or removed
  //Box Widget插件，启用这个插件允许框折叠或删除
  enableBoxWidget: true,
  //Box Widget plugin options
  //Box Widget 插件选项
  boxWidgetOptions: {
    boxWidgetIcons: {
      //Collapse icon
      //奔溃图标
      collapse: 'fa-minus',
      //Open icon
      //打开图标
      open: 'fa-plus',
      //Remove icon
      //删除图标
      remove: 'fa-times'
    },
    boxWidgetSelectors: {
      //Remove button selector
      //删除按钮选择器
      remove: '[data-widget="remove"]',
      //Collapse button selector
      //奔溃按钮选择器
      collapse: '[data-widget="collapse"]'
    }
  },
  //Direct Chat plugin options
  //Direct Chat 插件选项
  directChat: {
    //Enable direct chat by default
    //启用direct chat插件以默认方式
    enable: true,
    //The button to open and close the chat contacts pane
    //打开和关闭聊天联系人窗格的按钮
    contactToggleSelector: '[data-widget="chat-pane-toggle"]'
  },
  //Define the set of colors to use globally around the website
  //定义在网站上使用的颜色的集合
  colors: {
    lightBlue: "#3c8dbc",
    red: "#f56954",
    green: "#00a65a",
    aqua: "#00c0ef",
    yellow: "#f39c12",
    blue: "#0073b7",
    navy: "#001F3F",
    teal: "#39CCCC",
    olive: "#3D9970",
    lime: "#01FF70",
    orange: "#FF851B",
    fuchsia: "#F012BE",
    purple: "#8E24AA",
    maroon: "#D81B60",
    black: "#222222",
    gray: "#d2d6de"
  },
  //The standard screen sizes that bootstrap uses.
  //引导使用的标准屏幕大小
  //If you change these in the variables.less file, change them here too.
  //如果你在variables.less文件里面改变了这些，在这里也要改变
  screenSizes: {
    xs: 480,
    sm: 768,
    md: 992,
    lg: 1200
  }
};

/* ------------------
 * - Implementation -实施
 * ------------------
 * The next block of code implements AdminLTE's
 * functions and plugins as specified by the
 * options above.
 * 接下来的代码块实现的功能和插件的adminlte上面指定的选项。 
 */
$(function () {
  "use strict";//使用严格模式

  //Fix for IE page transitions
  $("body").removeClass("hold-transition");

  //Extend options if external options exist
  //如果外部扩展存在，延长扩展
  if (typeof AdminLTEOptions !== "undefined") {
    $.extend(true,
      $.AdminLTE.options,
      AdminLTEOptions);
  }

  //Easy access to options
  //轻松访问选项
  var o = $.AdminLTE.options;

  //Set up the object
  //设置对象
  _init();

  //Activate the layout maker
  //激活布局
  $.AdminLTE.layout.activate();

  //Enable sidebar tree view controls
  //启用侧边栏树视图控制
  $.AdminLTE.tree('.sidebar');

  //Enable control sidebar
  //启用侧边栏控制
  if (o.enableControlSidebar) {
    $.AdminLTE.controlSidebar.activate();
  }

  //Add slimscroll to navbar dropdown
  //添加slimscroll到下拉导航栏
  if (o.navbarMenuSlimscroll && typeof $.fn.slimscroll != 'undefined') {
    $(".navbar .menu").slimscroll({
      height: o.navbarMenuHeight,
      alwaysVisible: false,
      size: o.navbarMenuSlimscrollWidth
    }).css("width", "100%");
  }

  //Activate sidebar push menu
  //激活侧边栏目录
  if (o.sidebarPushMenu) {
    $.AdminLTE.pushMenu.activate(o.sidebarToggleSelector);
  }

  //Activate Bootstrap tooltip--激活Bootstrap工具提示
  if (o.enableBSToppltip) {
    $('body').tooltip({
      selector: o.BSTooltipSelector
    });
  }

  //Activate box widget--激活box widget(装置)
  if (o.enableBoxWidget) {
    $.AdminLTE.boxWidget.activate();
  }

  //Activate fast click--激活fast click
  if (o.enableFastclick && typeof FastClick != 'undefined') {
    FastClick.attach(document.body);
  }

  //Activate direct chat widget--激活direct chat widget
  if (o.directChat.enable) {
    $(document).on('click', o.directChat.contactToggleSelector, function () {
      var box = $(this).parents('.direct-chat').first();
      box.toggleClass('direct-chat-contacts-open');
    });
  }

  /*
   * INITIALIZE BUTTON TOGGLE--初始化按钮切换
   * ------------------------
   */
  $('.btn-group[data-toggle="btn-toggle"]').each(function () {
    var group = $(this);
    $(this).find(".btn").on('click', function (e) {
      group.find(".btn.active").removeClass("active");
      $(this).addClass("active");
      e.preventDefault();//阻止默认事件
    });

  });
});

/* ----------------------------------
 * - Initialize the AdminLTE Object -初始化AdminLTE对象
 * ----------------------------------
 * All AdminLTE functions are implemented below.--所有的AdminLTE函数在下面实现
 */
function _init() {
  'use strict';
  /* Layout
   * ======
   * Fixes the layout height in case min-height fails.
   *在最小高度失败的情况下修复布局高度
   * @type Object
   * @usage $.AdminLTE.layout.activate()
   *        $.AdminLTE.layout.fix()
   *        $.AdminLTE.layout.fixSidebar()
   */
  $.AdminLTE.layout = {
    activate: function () {
      var _this = this;
      _this.fix();
      _this.fixSidebar();
      $(window, ".wrapper").resize(function () {
        _this.fix();
        _this.fixSidebar();
      });
    },
    fix: function () { 
      //Get window height and the wrapper height--获取窗口高度和内容高度
      var neg = $('.main-header').outerHeight() + $('.main-footer').outerHeight();
      var window_height = $(window).height();
      var sidebar_height = $(".sidebar").height();
      //Set the min-height of the content and sidebar based on the height of the document.
      //设置最小内容区和侧边栏最小高度依据document的高度
      if ($("body").hasClass("fixed")) {
        $(".content-wrapper, .right-side").css('min-height', window_height - $('.main-footer').outerHeight());
      } else {
        var postSetWidth;
        if (window_height >= sidebar_height) {//窗口高度大于侧边栏高度
          $(".content-wrapper, .right-side").css('min-height', window_height - neg);
          postSetWidth = window_height - neg;
        } else {
          $(".content-wrapper, .right-side").css('min-height', sidebar_height);
          postSetWidth = sidebar_height;
        }

        //Fix for the control sidebar height--修复控制侧边栏高度
        var controlSidebar = $($.AdminLTE.options.controlSidebarOptions.selector);
        if (typeof controlSidebar !== "undefined") {
          if (controlSidebar.height() > postSetWidth)
            $(".content-wrapper, .right-side").css('min-height', controlSidebar.height());
        }

      }
    },
    fixSidebar: function () {
      //Make sure the body tag has the .fixed class--确保body标签有fixed的类
      if (!$("body").hasClass("fixed")) {
        if (typeof $.fn.slimScroll != 'undefined') {
          $(".sidebar").slimScroll({destroy: true}).height("auto");
        }
        return;
      } else if (typeof $.fn.slimScroll == 'undefined' && window.console) {
        window.console.error("Error: the fixed layout requires the slimscroll plugin!");
      }
      //Enable slimscroll for fixed layout--使slimscroll用固定布局
      if ($.AdminLTE.options.sidebarSlimScroll) {
        if (typeof $.fn.slimScroll != 'undefined') {
          //Destroy if it exists--如果存在，取消
          $(".sidebar").slimScroll({destroy: true}).height("auto");
          //Add slimscroll--添加slimscroll
          $(".sidebar").slimscroll({
            height: ($(window).height() - $(".main-header").height()) + "px",
            color: "rgba(0,0,0,0.2)",
            size: "3px"
          });
        }
      }
    }
  };

  /* PushMenu()
   * ==========
   * Adds the push menu functionality to the sidebar.--给侧边栏加push menu的功能
   *
   * @type Function
   * @usage: $.AdminLTE.pushMenu("[data-toggle='offcanvas']")
   */
  $.AdminLTE.pushMenu = {
    activate: function (toggleBtn) {
      //Get the screen sizes--获取屏幕尺寸
      var screenSizes = $.AdminLTE.options.screenSizes;
 
      //Enable sidebar toggle--使侧边栏切换
      $(document).on('click', toggleBtn, function (e) {
        e.preventDefault();

        //Enable sidebar push menu--使侧边栏push menu
        if ($(window).width() > (screenSizes.sm - 1)) {
          if ($("body").hasClass('sidebar-collapse')) {
            $("body").removeClass('sidebar-collapse').trigger('expanded.pushMenu');
          } else {
            $("body").addClass('sidebar-collapse').trigger('collapsed.pushMenu');
          }
        }
        //Handle sidebar push menu for small screens--小屏幕手柄菜单push menu
        else {
          if ($("body").hasClass('sidebar-open')) {
            $("body").removeClass('sidebar-open').removeClass('sidebar-collapse').trigger('collapsed.pushMenu');
          } else {
            $("body").addClass('sidebar-open').trigger('expanded.pushMenu');
          }
        }
      });

      $(".content-wrapper").click(function () {
        //Enable hide menu when clicking on the content-wrapper on small screens
        //在小屏幕上单击内容包装时启用“隐藏”菜单
        if ($(window).width() <= (screenSizes.sm - 1) && $("body").hasClass("sidebar-open")) {
          $("body").removeClass('sidebar-open');
        }
      });

      //Enable expand on hover for sidebar mini--使mini侧边栏在鼠标悬浮时放大
      if ($.AdminLTE.options.sidebarExpandOnHover
        || ($('body').hasClass('fixed')
        && $('body').hasClass('sidebar-mini'))) {
        this.expandOnHover();
      }
    },
    expandOnHover: function () {
      var _this = this;
      var screenWidth = $.AdminLTE.options.screenSizes.sm - 1;
      //Expand sidebar on hover--使菜单栏悬浮
      $('.main-sidebar').hover(function () {
        if ($('body').hasClass('sidebar-mini')
          && $("body").hasClass('sidebar-collapse')
          && $(window).width() > screenWidth) {
          _this.expand();
        }
      }, function () {
        if ($('body').hasClass('sidebar-mini')
          && $('body').hasClass('sidebar-expanded-on-hover')
          && $(window).width() > screenWidth) {
          _this.collapse();
        }
      });
    },
    expand: function () {
      $("body").removeClass('sidebar-collapse').addClass('sidebar-expanded-on-hover');
    },
    collapse: function () {
      if ($('body').hasClass('sidebar-expanded-on-hover')) {
        $('body').removeClass('sidebar-expanded-on-hover').addClass('sidebar-collapse');
      }
    }
  };

  /* Tree()
   * ======
   * Converts the sidebar into a multilevel tree view menu.--转换成一个多层次的树状视图菜单栏
   *
   * @type Function
   * @Usage: $.AdminLTE.tree('.sidebar')
   */
  $.AdminLTE.tree = function (menu) {
    var _this = this;
    var animationSpeed = $.AdminLTE.options.animationSpeed;
    $(document).off('click', menu + ' li a')
      .on('click', menu + ' li a', function (e) {
        //Get the clicked link and the next element--获取单击的链接和下一个元素
        var $this = $(this);
        var checkElement = $this.next();

        //Check if the next element is a menu and is visible--检查下一个元素是否是一个菜单，并且是可见的
        if ((checkElement.is('.treeview-menu')) && (checkElement.is(':visible')) && (!$('body').hasClass('sidebar-collapse'))) {
          //Close the menu--关闭菜单
          checkElement.slideUp(animationSpeed, function () {
            checkElement.removeClass('menu-open');
            //Fix the layout in case the sidebar stretches over the height of the window
            //_this.layout.fix();
          });
          checkElement.parent("li").removeClass("active");
        }
        //If the menu is not visible--如果菜单是不可见的
        else if ((checkElement.is('.treeview-menu')) && (!checkElement.is(':visible'))) {
          //Get the parent menu--获取父菜单
          var parent = $this.parents('ul').first();
          //Close all open menus within the parent--在父内关闭所有打开的菜单
          var ul = parent.find('ul:visible').slideUp(animationSpeed);
          //Remove the menu-open class from the parent--从父菜单中删除菜单打开类
          ul.removeClass('menu-open');
          //Get the parent li--获取父节点li
          var parent_li = $this.parent("li");

          //Open the target menu and add the menu-open class--打开目标菜单和添加menu-open类
          checkElement.slideDown(animationSpeed, function () {
            //Add the class active to the parent li--添加active类到父节点li
            checkElement.addClass('menu-open');
            parent.find('li.active').removeClass('active');
            parent_li.addClass('active');
            //Fix the layout in case the sidebar stretches over the height of the window
            _this.layout.fix();
          });
        }
        //if this isn't a link, prevent the page from being redirected--如果这不是一个链接，防止页面被重定向
        if (checkElement.is('.treeview-menu')) {
          e.preventDefault();
        }
      });
  };

  /* ControlSidebar
   * ==============
   * Adds functionality to the right sidebar--将功能添加到右侧边栏
   *
   * @type Object
   * @usage $.AdminLTE.controlSidebar.activate(options)
   */
  $.AdminLTE.controlSidebar = {
    //instantiate the object--实例化对象
    activate: function () {
      //Get the object--获得对象
      var _this = this;
      //Update options--更新选项
      var o = $.AdminLTE.options.controlSidebarOptions;
      //Get the sidebar--获得侧边栏
      var sidebar = $(o.selector);
      //The toggle button--切换按钮
      var btn = $(o.toggleBtnSelector);

      //Listen to the click event--侦听点击事件
      btn.on('click', function (e) {
        e.preventDefault();
        //If the sidebar is not open--如果侧边栏未打开
        if (!sidebar.hasClass('control-sidebar-open')
          && !$('body').hasClass('control-sidebar-open')) {
          //Open the sidebar--打开侧边栏
          _this.open(sidebar, o.slide);
        } else {
          _this.close(sidebar, o.slide);
        }
      });

      //If the body has a boxed layout, fix the sidebar bg position
      var bg = $(".control-sidebar-bg");
      _this._fix(bg);

      //If the body has a fixed layout, make the control sidebar fixed
      if ($('body').hasClass('fixed')) {
        _this._fixForFixed(sidebar);
      } else {
        //If the content height is less than the sidebar's height, force max height
        if ($('.content-wrapper, .right-side').height() < sidebar.height()) {
          _this._fixForContent(sidebar);
        }
      }
    },
    //Open the control sidebar--打开侧边栏控制
    open: function (sidebar, slide) {
      //Slide over content--幻灯片内容
      if (slide) {
        sidebar.addClass('control-sidebar-open');
      } else {
        //Push the content by adding the open class to the body instead of the sidebar itself
        //用添加open类到body的方式代替添加到其自身以展开内容
        $('body').addClass('control-sidebar-open');
      }
    },
    //Close the control sidebar--关闭侧边栏控制
    close: function (sidebar, slide) {
      if (slide) {
        sidebar.removeClass('control-sidebar-open');
      } else {
        $('body').removeClass('control-sidebar-open');
      }
    },
    _fix: function (sidebar) {
      var _this = this;
      if ($("body").hasClass('layout-boxed')) {
        sidebar.css('position', 'absolute');
        sidebar.height($(".wrapper").height());
        if (_this.hasBindedResize) {
          return;
        }
        $(window).resize(function () {
          _this._fix(sidebar);
        });
        _this.hasBindedResize = true;
      } else {
        sidebar.css({
          'position': 'fixed',
          'height': 'auto'
        });
      }
    },
    _fixForFixed: function (sidebar) {
      sidebar.css({
        'position': 'fixed',
        'max-height': '100%',
        'overflow': 'auto',
        'padding-bottom': '50px'
      });
    },
    _fixForContent: function (sidebar) {
      $(".content-wrapper, .right-side").css('min-height', sidebar.height());
    }
  };

  /* BoxWidget
   * =========
   * BoxWidget is a plugin to handle collapsing and
   * removing boxes from the screen.
   *
   * @type Object
   * @usage $.AdminLTE.boxWidget.activate()
   *        Set all your options in the main $.AdminLTE.options object
   */
  $.AdminLTE.boxWidget = {
    selectors: $.AdminLTE.options.boxWidgetOptions.boxWidgetSelectors,
    icons: $.AdminLTE.options.boxWidgetOptions.boxWidgetIcons,
    animationSpeed: $.AdminLTE.options.animationSpeed,
    activate: function (_box) {
      var _this = this;
      if (!_box) {
        _box = document; // activate all boxes per default
      }
      //Listen for collapse event triggers
      $(_box).on('click', _this.selectors.collapse, function (e) {
        e.preventDefault();
        _this.collapse($(this));
      });

      //Listen for remove event triggers
      $(_box).on('click', _this.selectors.remove, function (e) {
        e.preventDefault();
        _this.remove($(this));
      });
    },
    collapse: function (element) {
      var _this = this;
      //Find the box parent
      var box = element.parents(".box").first();
      //Find the body and the footer
      var box_content = box.find("> .box-body, > .box-footer, > form  >.box-body, > form > .box-footer");
      if (!box.hasClass("collapsed-box")) {
        //Convert minus into plus
        element.children(":first")
          .removeClass(_this.icons.collapse)
          .addClass(_this.icons.open);
        //Hide the content
        box_content.slideUp(_this.animationSpeed, function () {
          box.addClass("collapsed-box");
        });
      } else {
        //Convert plus into minus
        element.children(":first")
          .removeClass(_this.icons.open)
          .addClass(_this.icons.collapse);
        //Show the content
        box_content.slideDown(_this.animationSpeed, function () {
          box.removeClass("collapsed-box");
        });
      }
    },
    remove: function (element) {
      //Find the box parent
      var box = element.parents(".box").first();
      box.slideUp(this.animationSpeed);
    }
  };
}

/* ------------------
 * - Custom Plugins -
 * ------------------
 * All custom plugins are defined below.
 */

/*
 * BOX REFRESH BUTTON
 * ------------------
 * This is a custom plugin to use with the component BOX. It allows you to add
 * a refresh button to the box. It converts the box's state to a loading state.
 *
 * @type plugin
 * @usage $("#box-widget").boxRefresh( options );
 */
(function ($) {

  "use strict";

  $.fn.boxRefresh = function (options) {

    // Render options
    var settings = $.extend({
      //Refresh button selector
      trigger: ".refresh-btn",
      //File source to be loaded (e.g: ajax/src.php)
      source: "",
      //Callbacks
      onLoadStart: function (box) {
        return box;
      }, //Right after the button has been clicked
      onLoadDone: function (box) {
        return box;
      } //When the source has been loaded

    }, options);

    //The overlay
    var overlay = $('<div class="overlay"><div class="fa fa-refresh fa-spin"></div></div>');

    return this.each(function () {
      //if a source is specified
      if (settings.source === "") {
        if (window.console) {
          window.console.log("Please specify a source first - boxRefresh()");
        }
        return;
      }
      //the box
      var box = $(this);
      //the button
      var rBtn = box.find(settings.trigger).first();

      //On trigger click
      rBtn.on('click', function (e) {
        e.preventDefault();
        //Add loading overlay
        start(box);

        //Perform ajax call
        box.find(".box-body").load(settings.source, function () {
          done(box);
        });
      });
    });

    function start(box) {
      //Add overlay and loading img
      box.append(overlay);

      settings.onLoadStart.call(box);
    }

    function done(box) {
      //Remove overlay and loading img
      box.find(overlay).remove();

      settings.onLoadDone.call(box);
    }

  };

})(jQuery);

/*
 * EXPLICIT BOX CONTROLS
 * -----------------------
 * This is a custom plugin to use with the component BOX. It allows you to activate
 * a box inserted in the DOM after the app.js was loaded, toggle and remove box.
 *
 * @type plugin
 * @usage $("#box-widget").activateBox();
 * @usage $("#box-widget").toggleBox();
 * @usage $("#box-widget").removeBox();
 */
(function ($) {

  'use strict';

  $.fn.activateBox = function () {
    $.AdminLTE.boxWidget.activate(this);
  };

  $.fn.toggleBox = function () {
    var button = $($.AdminLTE.boxWidget.selectors.collapse, this);
    $.AdminLTE.boxWidget.collapse(button);
  };

  $.fn.removeBox = function () {
    var button = $($.AdminLTE.boxWidget.selectors.remove, this);
    $.AdminLTE.boxWidget.remove(button);
  };

})(jQuery);

/*
 * TODO LIST CUSTOM PLUGIN
 * -----------------------
 * This plugin depends on iCheck plugin for checkbox and radio inputs
 *
 * @type plugin
 * @usage $("#todo-widget").todolist( options );
 */
(function ($) {

  'use strict';

  $.fn.todolist = function (options) {
    // Render options
    var settings = $.extend({
      //When the user checks the input
      onCheck: function (ele) {
        return ele;
      },
      //When the user unchecks the input
      onUncheck: function (ele) {
        return ele;
      }
    }, options);

    return this.each(function () {

      if (typeof $.fn.iCheck != 'undefined') {
        $('input', this).on('ifChecked', function () {
          var ele = $(this).parents("li").first();
          ele.toggleClass("done");
          settings.onCheck.call(ele);
        });

        $('input', this).on('ifUnchecked', function () {
          var ele = $(this).parents("li").first();
          ele.toggleClass("done");
          settings.onUncheck.call(ele);
        });
      } else {
        $('input', this).on('change', function () {
          var ele = $(this).parents("li").first();
          ele.toggleClass("done");
          if ($('input', ele).is(":checked")) {
            settings.onCheck.call(ele);
          } else {
            settings.onUncheck.call(ele);
          }
        });
      }
    });
  };
}(jQuery));
