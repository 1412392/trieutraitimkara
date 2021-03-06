(function(n) {
    n.fn.extend({
        autocomplete: function(t, i) {
            var r = typeof t == "string";
            return i = n.extend({}, n.Autocompleter.defaults, {
                url: r ? t : null,
                data: r ? null : t,
                delay: r ? n.Autocompleter.defaults.delay : 10,
                max: 500
            }, i), i.highlight = i.highlight || function(n) {
                return n
            }, i.formatMatch = i.formatMatch || i.formatItem, this.each(function() {
                new n.Autocompleter(this, i)
            })
        },
        result: function(n) {
            return this.bind("result", n)
        },
        search: function(n) {
            return this.trigger("search", [n])
        },
        flushCache: function() {
            return this.trigger("flushCache")
        },
        setOptions: function(n) {
            return this.trigger("setOptions", [n])
        },
        unautocomplete: function() {
            return this.trigger("unautocomplete")
        }
    });
    n.Autocompleter = function(t, i) {
        function k() {
            var h = r.selected(),
                f, o;
            if (!h) return !1;
            if (f = h.result, e = f, i.multiple) {
                if (o = s(u.val()), o.length > 1) {
                    var a = i.multipleSeparator.length,
                        y = n(t).selection().start,
                        l, c = 0;
                    n.each(o, function(n, t) {
                        if (c += t.length, y <= c) return l = n, !1;
                        c += a
                    });
                    o[l] = f;
                    f = o.join(i.multipleSeparator)
                }
                f += i.multipleSeparator
            }
            return u.val(f), v(), u.trigger("result", [h.data, h.value]), !0
        }

        function o(n, t) {
            if (y == f.DEL) {
                r.hide();
                return
            }
            var o = u.val();
            (t || o != e) && (e = o, o = a(o), o.length >= i.minChars ? (u.addClass(i.loadingClass), i.matchCase || (o = o.toLowerCase()), d(o, tt, v)) : (w(), r.hide()))
        }

        function s(t) {
            return t ? i.multiple ? n.map(t.split(i.multipleSeparator), function(i) {
                return n.trim(t).length ? n.trim(i) : null
            }) : [n.trim(t)] : [""]
        }

        function a(r) {
            var u, f;
            return i.multiple ? (u = s(r), u.length == 1) ? u[0] : (f = n(t).selection().start, u = f == r.length ? s(r) : s(r.replace(r.substring(f), "")), u[u.length - 1]) : r
        }

        function g(r, o) {
            i.autoFill && a(u.val()).toLowerCase() == r.toLowerCase() && y != f.BACKSPACE && (u.val(u.val() + o.substring(a(e).length)), n(t).selection(e.length, e.length + o.length))
        }

        function nt() {
            clearTimeout(h);
            h = setTimeout(v, 200)
        }

        function v() {
            var n = r.visible();
            r.hide();
            clearTimeout(h);
            w();
            i.mustMatch && u.search(function(n) {
                if (!n)
                    if (i.multiple) {
                        var t = s(u.val()).slice(0, -1);
                        u.val(t.join(i.multipleSeparator) + (t.length ? i.multipleSeparator : ""))
                    } else u.val(""), u.trigger("result", null)
            })
        }

        function tt(n, t) {
            t && t.length && c ? (w(), r.display(t, n), g(n, t[0].value), r.show()) : v()
        }

        function d(u, f, e) {
            var o, s;
            i.matchCase || (u = u.toLowerCase());
            o = l.load(u);
            o && o.length ? f(u, o) : typeof i.url == "string" && i.url.length > 0 ? (s = {
                timestamp: +new Date
            }, n.each(i.extraParams, function(n, t) {
                s[n] = typeof t == "function" ? t() : t
            }), n.ajax({
                mode: "abort",
                port: "autocomplete" + t.name,
                dataType: i.dataType,
                url: i.url,
                data: n.extend({
                    q: a(u),
                    limit: 500
                }, s),
                success: function(n) {
                    var t = i.parse && i.parse(n) || it(n);
                    l.add(u, t);
                    f(u, t)
                }
            })) : (r.emptyList(), e(u))
        }

        function it(t) {
			 
            for (var r, u = [], e = t.split("\n"), f = 0; f < e.length; f++) r = n.trim(e[f]), r && (r = r.split("|"), u[u.length] = {
                data: r,
                value: r[0],
                result: i.formatResult && i.formatResult(r, r[0]) || r[0]
            });
            return u
        }

        function w() {
            u.removeClass(i.loadingClass)
        }
        var f = {
                UP: 38,
                DOWN: 40,
                DEL: 46,
                TAB: 9,
                RETURN: 13,
                ESC: 27,
                COMMA: 188,
                PAGEUP: 33,
                PAGEDOWN: 34,
                BACKSPACE: 8
            },
            u = n(t).attr("autocomplete", "off").addClass(i.inputClass),
            h, e = "",
            l = n.Autocompleter.Cache(i),
            c = 0,
            y, b = {
                mouseDownOnSelect: !1
            },
            r = n.Autocompleter.Select(i, t, k, b),
            p;
          n(t.form).bind("submit.autocomplete", function() {
            if (p) return p = !1, !1
        });
        u.bind((  "keydown") + ".autocomplete", function(t) {
            c = 1;
            y = t.keyCode;
            switch (t.keyCode) {
                case f.UP:
                    t.preventDefault();
                    r.visible() ? r.prev() : o(0, !0);
                    break;
                case f.DOWN:
                    t.preventDefault();
                    r.visible() ? r.next() : o(0, !0);
                    break;
                case f.PAGEUP:
                    t.preventDefault();
                    r.visible() ? r.pageUp() : o(0, !0);
                    break;
                case f.PAGEDOWN:
                    t.preventDefault();
                    r.visible() ? r.pageDown() : o(0, !0);
                    break;
                case i.multiple && n.trim(i.multipleSeparator) == "," && f.COMMA:
                case f.TAB:
                case f.RETURN:
                    if (k()) return t.preventDefault(), p = !0, !1;
                    break;
                case f.ESC:
                    r.hide();
                    break;
                default:
                    clearTimeout(h);
                    h = setTimeout(o, i.delay)
            }
        }).focus(function() {
            c++
        }).blur(function() {
            c = 0;
            b.mouseDownOnSelect || nt()
        }).click(function() {
            c++ > 1 && !r.visible() && o(0, !0)
        }).bind("search", function() {
            function i(n, i) {
                var r, f;
                if (i && i.length)
                    for (f = 0; f < i.length; f++)
                        if (i[f].result.toLowerCase() == n.toLowerCase()) {
                            r = i[f];
                            break
                        }
                typeof t == "function" ? t(r) : u.trigger("result", r && [r.data, r.value])
            }
            var t = arguments.length > 1 ? arguments[1] : null;
            n.each(s(u.val()), function(n, t) {
                d(t, i, i)
            })
        }).bind("flushCache", function() {
            l.flush()
        }).bind("setOptions", function() {
            n.extend(i, arguments[1]);
            "data" in arguments[1] && l.populate()
        }).bind("unautocomplete", function() {
            r.unbind();
            u.unbind();
            n(t.form).unbind(".autocomplete")
        })
    };
    n.Autocompleter.defaults = {
        inputClass: "ac_input",
        resultsClass: "ac_results",
        loadingClass: "ac_loading",
        minChars: 1,
      
        delay: 400,
        matchCase: !1,
        matchSubset: !0,
        matchContains: !1,
        cacheLength: 10,
        max: 500,
        mustMatch: !1,
        extraParams: {},
        selectFirst: !0,
        formatItem: function(n) {
            return n[0]
        },
        formatMatch: null,
        autoFill: !1,
        width: 0,
        multiple: !1,
        multipleSeparator: ", ",
        highlight: function(n, t) {
            return n.replace(new RegExp("(?![^&;]+;)(?!<[^<>]*)(" + t.replace(/([\^\$\(\)\[\]\{\}\*\.\+\?\|\\])/gi, "\\$1") + ")(?![^<>]*>)(?![^&;]+;)", "gi"), "<strong>$1<\/strong>")
        },
        scroll: !0,
        scrollHeight: 180
    };
    n.Autocompleter.Cache = function(t) {
        function u(n, i) {
            t.matchCase || (n = n.toLowerCase());
            var r = n.indexOf(i);
            return (t.matchContains == "word" && (r = n.toLowerCase().search("\\b" + i.toLowerCase())), r == -1) ? !1 : r == 0 || t.matchContains
        }

        function f(n, u) {
            r > t.cacheLength && o();
            i[n] || r++;
            i[n] = u
        }

        function e() {
            var r, h, u, c, i, e, o, s;
            if (!t.data) return !1;
            for (r = {}, h = 0, t.url || (t.cacheLength = 1), r[""] = [], u = 0, c = t.data.length; u < c; u++)(i = t.data[u], i = typeof i == "string" ? [i] : i, e = t.formatMatch(i, u + 1, t.data.length), e !== !1) && (o = e.charAt(0).toLowerCase(), r[o] || (r[o] = []), s = {
                value: e,
                data: i,
                result: t.formatResult && t.formatResult(i) || e
            }, r[o].push(s), h++ < t.max && r[""].push(s));
            n.each(r, function(n, i) {
                t.cacheLength++;
                f(n, i)
            })
        }

        function o() {
            i = {};
            r = 0
        }
        var i = {},
            r = 0;
        return setTimeout(e, 25), {
            flush: o,
            add: f,
            populate: e,
            load: function(f) {
                var h, s, o, e;
                if (!t.cacheLength || !r) return null;
                if (!t.url && t.matchContains) {
                    e = [];
                    for (h in i) h.length > 0 && (o = i[h], n.each(o, function(n, t) {
                        u(t.value, f) && e.push(t)
                    }));
                    return e
                }
                if (i[f]) return i[f];
                if (t.matchSubset)
                    for (s = f.length - 1; s >= t.minChars; s--)
                        if (o = i[f.substr(0, s)], o) return e = [], n.each(o, function(n, t) {
                            u(t.value, f) && (e[e.length] = t)
                        }), e;
                return null
            }
        }
    };
    n.Autocompleter.Select = function(t, i, r, u) {
        function p() {
            y && (h = n("<div/>").hide().addClass(t.resultsClass).css("position", "absolute").appendTo(document.body), o = n("<ul/>").appendTo(h).mouseover(function(t) {
                a(t).nodeName && a(t).nodeName.toUpperCase() == "LI" && (e = n("li", o).removeClass(s.ACTIVE).index(a(t)), n(a(t)).addClass(s.ACTIVE))
            }).click(function(t) {
                return n(a(t)).addClass(s.ACTIVE), r(), i.focus(), !1
            }).mousedown(function() {
                u.mouseDownOnSelect = !0
            }).mouseup(function() {
                u.mouseDownOnSelect = !1
            }), t.width > 0 && h.css("width", t.width), y = !1)
        }

        function a(n) {
            for (var t = n.target; t && t.tagName != "LI";) t = t.parentNode;
            return t ? t : []
        }

        function l(n) {
            var r, i;
            f.slice(e, e + 1).removeClass(s.ACTIVE);
            w(n);
            r = f.slice(e, e + 1).addClass(s.ACTIVE);
            t.scroll && (i = 0, f.slice(0, e).each(function() {
                i += this.offsetHeight
            }), i + r[0].offsetHeight - o.scrollTop() > o[0].clientHeight ? o.scrollTop(i + r[0].offsetHeight - o.innerHeight()) : i < o.scrollTop() && o.scrollTop(i))
        }

        function w(n) {
            e += n;
            e < 0 ? e = f.length - 1 : e >= f.length && (e = 0)
        }

        function b(n) {
            return t.max && t.max < n ? t.max : n
        }

        function k() {
            var r, i, u, h;
            for (o.empty(), r = b(c.length), i = 0; i < r; i++) c[i] && (u = t.formatItem(c[i].data, i + 1, r, c[i].value, v), u !== !1) && (h = n("<li/>").html(t.highlight(u, v)).addClass(i % 2 == 0 ? "ac_even" : "ac_odd").appendTo(o)[0], n.data(h, "ac_data", c[i]));
            f = o.find("li");
            t.selectFirst && (f.slice(0, 1).addClass(s.ACTIVE), e = 0);
            n.fn.bgiframe && o.bgiframe()
        }
        var s = {
                ACTIVE: "ac_over"
            },
            f, e = -1,
            c, v = "",
            y = !0,
            h, o;
        return {
            display: function(n, t) {
                p();
                c = n;
                v = t;
                k()
            },
            next: function() {
                l(1)
            },
            prev: function() {
                l(-1)
            },
            pageUp: function() {
                e != 0 && e - 8 < 0 ? l(-e) : l(-8)
            },
            pageDown: function() {
                e != f.size() - 1 && e + 8 > f.size() ? l(f.size() - 1 - e) : l(8)
            },
            hide: function() {
                h && h.hide();
                f && f.removeClass(s.ACTIVE);
                e = -1
            },
            visible: function() {
                return h && h.is(":visible")
            },
            current: function() {
                return this.visible() && (f.filter("." + s.ACTIVE)[0] || t.selectFirst && f[0])
            },
            show: function() {
                var e = n(i).offset(),
                    r, u;
                h.css({
                    width: typeof t.width == "string" || t.width > 0 ? t.width : n(i).width(),
                    top: e.top + i.offsetHeight,
                    left: e.left
                }).show();
                t.scroll && (o.scrollTop(0), o.css({
                    maxHeight: t.scrollHeight,
                    overflow: "auto"
                }),  typeof document.body.style.maxHeight == "undefined" && (r = 0, f.each(function() {
                    r += this.offsetHeight
                }), u = r > t.scrollHeight, o.css("height", u ? t.scrollHeight : r), u || f.width(o.width() - parseInt(f.css("padding-left")) - parseInt(f.css("padding-right")))))
            },
            selected: function() {
                var t = f && f.filter("." + s.ACTIVE).removeClass(s.ACTIVE);
                return t && t.length && n.data(t[0], "ac_data")
            },
            emptyList: function() {
                o && o.empty()
            },
            unbind: function() {
                h && h.remove()
            }
        }
    };
    n.fn.selection = function(n, t) {
        var i, r;
        if (n !== undefined) return this.each(function() {
            if (this.createTextRange) {
                var i = this.createTextRange();
                t === undefined || n == t ? (i.move("character", n), i.select()) : (i.collapse(!0), i.moveStart("character", n), i.moveEnd("character", t), i.select())
            } else this.setSelectionRange ? this.setSelectionRange(n, t) : this.selectionStart && (this.selectionStart = n, this.selectionEnd = t)
        });
        if (i = this[0], i.createTextRange) {
            var u = document.selection.createRange(),
                o = i.value,
                f = "<->",
                e = u.text.length;
            return u.text = f, r = i.value.indexOf(f), i.value = o, this.selection(r, r + e), {
                start: r,
                end: r + e
            }
        }
        if (i.selectionStart !== undefined) return {
            start: i.selectionStart,
            end: i.selectionEnd
        }
    }
})(jQuery);