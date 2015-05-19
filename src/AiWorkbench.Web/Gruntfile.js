/// <binding AfterBuild='default' ProjectOpened='watch' />
module.exports = function (grunt) {
	grunt.initConfig({
		bower: {
			install: {
				options: {
					cleanup: false,
					targetDir: 'wwwroot/lib',
					layout: 'byType',
				}
			}
		},
		watch: {
			less: {
				files: 'Styles/**/*.less',
				tasks: ['clean:css', 'less']
			},
			js: {
			    files: 'Scripts/**/*.js',
                tasks: ['clean:js', 'copy']
			}
		},
		less: {
			all: {
				options: {
					paths: ['Styles'],
                    sourceMap: true
				},
				files: [{
					expand: true,
					cwd: 'Styles',
					src: ['*.less'],
					ext: '.css',
					dest: 'wwwroot/src/css/'
				}]
			}
		},
		copy: {
		    all: {
		        files: [
                    { expand: true, cwd: 'Scripts', src: ['**/*.js'], dest: 'wwwroot/src/js' }
		        ]
		    }
		},
		clean: {
            css: ['wwwroot/src/css'],
            js: ['wwwroot/src/js']
		},
		autoprefixer: {
		    options: {
		        browsers: ['> 5%']
		    },
		    all: {
		        files: [{
		            expand: true,
		            cwd: 'wwwroot/src/css',
		            src: ['*.css'],
		            ext: '.css',
		            dest: 'wwwroot/src/css'
		        }]
		    }
		}
	});

	grunt.loadNpmTasks('grunt-bower-task');
	grunt.loadNpmTasks('grunt-contrib-less');
	grunt.loadNpmTasks('grunt-contrib-watch');
	grunt.loadNpmTasks('grunt-contrib-copy')
	grunt.loadNpmTasks('grunt-contrib-clean');
	grunt.loadNpmTasks('grunt-autoprefixer');

	grunt.registerTask('default', ['bower', 'clean', 'less', 'autoprefixer', 'copy']);
};