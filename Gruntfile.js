module.exports = function(grunt) {
  grunt.initConfig({
    pkg: grunt.file.readJSON('package.json'),

    sass: {
      options: {
        includePaths: ['bower_components/foundation/scss']
      },
      dist: {
        options: {
          outputStyle: 'compressed',
          sourceMap: true,
        },
        files: {
          'css/app.css': 'scss/app.scss'
        }
      }
    },

    svg2png: {
        all: {
            // specify files in array format with multiple src-dest mapping
            files: [
                // rasterize all SVG files in "img" and its subdirectories to "img/png"
                { src: ['images/**/*.svg'], dest: '' },
                // rasterize SVG file to same directory
                // { src: ['images/logo.svg'] }
            ]
        }
    },

    watch: {
      grunt: {
        options: {
          reload: true
        },
        files: ['Gruntfile.js']
      },

      sass: {
        files: 'scss/**/*.scss',
        tasks: ['sass']
      }
    }
  });

  grunt.loadNpmTasks('grunt-sass');
  grunt.loadNpmTasks('grunt-svg2png');
  grunt.loadNpmTasks('grunt-contrib-watch');

  grunt.registerTask('image', ['svg2png']);
  grunt.registerTask('build', ['sass']);
  grunt.registerTask('default', ['build','watch']);
}
